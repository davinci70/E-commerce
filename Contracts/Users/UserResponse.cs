namespace e_commerce.Contracts.Users;

public record UserResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    bool IsDisabled,
    IEnumerable<string> Roles
);
