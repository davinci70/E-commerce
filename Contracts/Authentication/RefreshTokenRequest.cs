namespace e_commerce.Contracts.Authentication;

public record RefreshTokenRequest(
    string Token,
    string RefreshToken
);
