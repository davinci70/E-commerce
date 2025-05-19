namespace e_commerce.Contracts.Carts;

public record CartRequest(
    int ProductId,
    int Quantity
);
