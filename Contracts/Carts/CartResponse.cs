namespace e_commerce.Contracts.Carts;

public record CartResponse(
    int Id,
    decimal TotalPrice,
    List<CartItemResponse> CartItems
);
