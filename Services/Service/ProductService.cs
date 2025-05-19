
using System.Linq.Dynamic.Core;

namespace e_commerce.Services.Service;

public class ProductService(ApplicationDbContext context, CloudinaryService cloudinaryService) : IProductService
{
    private readonly ApplicationDbContext _context = context;
    private readonly CloudinaryService _cloudinaryService = cloudinaryService;

    public async Task<Result<ProductResponse>> AddAsync(ProductRequest request, CancellationToken cancellationToken = default)
    {
        if (await _context.ProductTypes.FindAsync(request.ProductTypeId, cancellationToken) is not { } productType)
            return Result.Failure<ProductResponse>(ProductTypeErrors.ProductTypeNotFound);

        var product = request.Adapt<Product>();

        if (request.ProductImages != null)
        {
            foreach (var image in request.ProductImages)
            {
                var imageUrl = await _cloudinaryService.UploadImageAsync(image);
                product.ProductImages.Add(new ProductImage { ImageUrl = imageUrl });
            }
        }

        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(product.Adapt<ProductResponse>());
    }
    public async Task<Result<PaginatedList<ProductResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = _context.Products
            .Where(x => !x.IsDeleted); 


        if (!string.IsNullOrEmpty(filters.SearchValue))
        {
            query = query.Where(x => x.Name.Contains(filters.SearchValue));
        }

        if (!string.IsNullOrEmpty(filters.SortColumn))
        {
            query = query.OrderBy($"{filters.SortColumn} {filters.SortDirection}");
        }

        var source = query
            .ProjectToType<ProductResponse>()
            .AsNoTracking();

        var products = await PaginatedList<ProductResponse>.CreateAsync(source, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(products);
    }
    public async Task<Result<ProductResponse>> GetAsync(int Id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.
            Where(x => x.Id == Id && !x.IsDeleted)
            .ProjectToType<ProductResponse>()
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        return product is not null ? Result.Success(product) : Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
    }
    public async Task<Result> UpdateAsync(int Id, UpdateProductRequest request, CancellationToken cancellationToken = default)
    {
        var currentProduct = await _context.Products
            .Where(x => x.Id == Id && !x.IsDeleted)
            .Include(x => x.ProductImages)
            .FirstOrDefaultAsync(cancellationToken);

        if (currentProduct is null)
            return Result.Failure(ProductErrors.ProductNotFound);

        if (await _context.ProductTypes.FindAsync(request.ProductTypeId, cancellationToken) is not { } productType)
            return Result.Failure<ProductResponse>(ProductTypeErrors.ProductTypeNotFound);

        currentProduct = request.Adapt(currentProduct);

        if (request.RemoveImagesIds != null && request.RemoveImagesIds.Any())
        {
            foreach (var imageId in request.RemoveImagesIds)
            {
                var image = currentProduct.ProductImages.FirstOrDefault(x => x.Id == imageId);

                if (image != null)
                {
                    await _cloudinaryService.DeleteImageAsync(image.ImageUrl);
                    _context.ProductImages.Remove(image);
                }
            }
        }

        if (request.ProductImages != null && request.ProductImages.Any())
        {
            foreach (var newImage in request.ProductImages)
            {
                var imageUrl = await _cloudinaryService.UploadImageAsync(newImage);
                currentProduct.ProductImages.Add(new ProductImage { ImageUrl = imageUrl });
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }  
    public async Task<Result> ToggleAsync(int Id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .Where(x => x.Id == Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
            return Result.Failure(ProductErrors.ProductNotFound);

        product.IsDeleted = !product.IsDeleted;

        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
