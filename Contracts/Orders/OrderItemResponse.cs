namespace e_commerce.Contracts.Orders;

public record OrderItemResponse(
    int Id,
    int ProductId,
    string ItemName,
    decimal ItemPrice,
    int Quantity
);
