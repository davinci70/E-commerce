using e_commerce.Contracts.Common;

namespace e_commerce.Services.IService;

public interface IProductService
{
    Task<Result<PaginatedList<ProductResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<ProductResponse>> GetAsync(int Id, CancellationToken cancellationToken = default);
    Task<Result<ProductResponse>> AddAsync(ProductRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int Id, UpdateProductRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleAsync(int Id, CancellationToken cancellationToken = default);
}
