namespace e_commerce.Contracts.Authentication;

public record LoginRequest(
    string email,
    string password
    );
