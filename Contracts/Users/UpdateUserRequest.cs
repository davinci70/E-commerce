namespace e_commerce.Contracts.Users;

public record UpdateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    IList<string> Roles
);
