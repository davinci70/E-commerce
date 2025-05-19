namespace e_commerce.Contracts.Contracts;

public record UserProfileResponse(
    string Email,   
    string UserName,   
    string FirstName,   
    string LastName,
    string PhoneNumber
);
