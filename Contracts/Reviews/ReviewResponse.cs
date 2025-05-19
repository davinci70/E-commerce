namespace e_commerce.Contracts.Reviews;

public record ReviewResponse(
    int Id,
    int ProductId,
    string UserId,
    byte Rate,
    string Body
);
