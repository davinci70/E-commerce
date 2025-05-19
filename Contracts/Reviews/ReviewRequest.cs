namespace e_commerce.Contracts.Reviews;

public record ReviewRequest(
    int ProductId,
    byte Rate,
    string Body
);
