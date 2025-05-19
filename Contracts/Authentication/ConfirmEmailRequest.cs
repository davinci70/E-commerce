namespace e_commerce.Contracts.Authentication;

public record ConfirmEmailRequest(
    string UserId,
    string Code
);