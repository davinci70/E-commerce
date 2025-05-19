namespace e_commerce.Contracts.Users;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    IList<string> Roles
);
