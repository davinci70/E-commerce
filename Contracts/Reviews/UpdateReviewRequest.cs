namespace e_commerce.Contracts.Reviews;

public record UpdateReviewRequest(
    byte Rate,
    string Body
);
