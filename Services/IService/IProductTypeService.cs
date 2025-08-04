namespace e_commerce.Services.IService;

public interface IProductTypeService
{
    Task<Result<PaginatedList<ProductTypeResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductTypeLockupResponse>> LockupAsync(CancellationToken cancellationToken = default);
    Task<Result<ProductTypeResponse>> GetAsync(int Id, CancellationToken cancellationToken = default);
    Task<Result<ProductTypeResponse>> AddAsync(ProductTypeRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int Id, ProductTypeRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int Id, CancellationToken cancellationToken = default);
}
