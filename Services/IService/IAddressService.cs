namespace e_commerce.Services.IService;

public interface IAddressService
{
    Task<IEnumerable<AddressResponse>> GetByUserIdAsync(CancellationToken cancellationToken = default);
    Task<Result<AddressResponse>> GetAsync(int Id, CancellationToken cancellationToken = default);
    Task<Result<AddressResponse>> AddAsync(AddressRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int Id, AddressRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(int Id, CancellationToken cancellationToken = default);
}
