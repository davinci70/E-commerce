namespace e_commerce.Services.IService;

public interface IUserService
{
    Task<Result<PaginatedList<UserResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<UserResponse>> GetAsync(string UserId);
    Task<Result<UserProfileResponse>> GetProfileAsync(string UserId);
    Task<Result> UpdateProfileAsync(string UserId, UpdateProfileRequest request);
    Task<Result> ChangePasswordAsync(string UserId, ChangePasswordRequest request);
    Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken);
    Task<Result> ToggleStatusAsync(string id);
    Task<Result> Unlock(string id);
}
