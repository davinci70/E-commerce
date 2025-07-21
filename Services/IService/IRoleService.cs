namespace e_commerce.Services.IService;

public interface IRoleService
{
    Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default);
    Task<IEnumerable<PermissionResponse>> GetAllPermissionsAsync(CancellationToken cancellationToken = default);
    Task<Result<RoleDetailsResponse>> GetAsync(string Id);
    Task<Result<RoleDetailsResponse>> AddAsync(RoleRequest request);
    Task<Result> UpdateAsync(string id, RoleRequest request);
    Task<Result> ToggleStatusAsync(string id);
}
