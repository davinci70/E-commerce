
using static System.Net.Mime.MediaTypeNames;
using System.Linq.Dynamic.Core;

namespace e_commerce.Services.Service;

public class ProductTypeService(ApplicationDbContext context, CloudinaryService cloudinaryService) : IProductTypeService
{
    private readonly ApplicationDbContext _context = context;
    private readonly CloudinaryService _cloudinaryService = cloudinaryService;

    public async Task<Result<PaginatedList<ProductTypeResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = _context.ProductTypes.AsQueryable();

        if (!string.IsNullOrEmpty(filters.SearchValue))
        {
            query = query.Where(x => x.Title.Contains(filters.SearchValue));
        }

        if (!string.IsNullOrEmpty(filters.SortColumn))
        {
            query = query.OrderBy($"{filters.SortColumn} {filters.SortDirection}");
        }

        var source = query
            .ProjectToType<ProductTypeResponse>()
            .AsNoTracking();

        var productTypes = await PaginatedList<ProductTypeResponse>.CreateAsync(source, filters.PageNumber, filters.PageSize, cancellationToken);
        return Result.Success(productTypes);
    }
        
    
    public async Task<IEnumerable<ProductTypeLockupResponse>> LockupAsync(CancellationToken cancellationToken = default) =>
        await _context.ProductTypes
        .ProjectToType<ProductTypeLockupResponse>()
        .AsNoTracking()
        .ToListAsync(cancellationToken);

    public async Task<Result<ProductTypeResponse>> GetAsync(int Id, CancellationToken cancellationToken = default)
    {
        var productType = await _context.ProductTypes.FindAsync(Id, cancellationToken);

        return productType is not null ? Result.Success(productType.Adapt<ProductTypeResponse>()) : Result.Failure<ProductTypeResponse>(ProductTypeErrors.ProductTypeNotFound);
    }

    public async Task<Result<ProductTypeResponse>> AddAsync(ProductTypeRequest request, CancellationToken cancellationToken = default)
    {
        var IsTitleExists = await _context.ProductTypes.AnyAsync(x => x.Title.ToLower() == request.Title.ToLower(), cancellationToken);

        if (IsTitleExists)
            return Result.Failure<ProductTypeResponse>(ProductTypeErrors.DuplicatedTitle);

        var productType = request.Adapt<ProductType>();

        productType.ImageUrl = await _cloudinaryService.UploadImageAsync(request.ImageUrl);

        await _context.AddAsync(productType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(productType.Adapt<ProductTypeResponse>());
    }

    public async Task<Result> UpdateAsync(int Id, ProductTypeRequest request, CancellationToken cancellationToken = default)
    {
        var IsTitleExists = await _context.ProductTypes.AnyAsync(x => x.Title.ToLower() == request.Title.ToLower() && x.Id != Id, cancellationToken);
    
        if (IsTitleExists)
            return Result.Failure<ProductTypeResponse>(ProductTypeErrors.DuplicatedTitle);

        var currentProductType = await _context.ProductTypes.FindAsync(Id, cancellationToken);

        if (currentProductType is null)
            return Result.Failure(ProductTypeErrors.ProductTypeNotFound);

        currentProductType.ImageUrl = await _cloudinaryService.UploadImageAsync(request.ImageUrl);
        currentProductType.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int Id, CancellationToken cancellationToken = default)
    {
        var productType = await _context.ProductTypes.FindAsync(Id, cancellationToken);

        if (productType is null)
            return Result.Failure(ProductTypeErrors.ProductTypeNotFound);

        _context.ProductTypes.Remove(productType);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
