
using static System.Net.Mime.MediaTypeNames;

namespace e_commerce.Services.Service;

public class ProductTypeService(ApplicationDbContext context, CloudinaryService cloudinaryService) : IProductTypeService
{
    private readonly ApplicationDbContext _context = context;
    private readonly CloudinaryService _cloudinaryService = cloudinaryService;

    public async Task<IEnumerable<ProductTypeResponse>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.ProductTypes
        .ProjectToType<ProductTypeResponse>()
        .AsNoTracking()
        .ToListAsync(cancellationToken);
    
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
