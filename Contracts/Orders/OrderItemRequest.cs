namespace e_commerce.Contracts.Orders;

public record OrderItemRequest(
    int ProductId,
    //string ProductName,
    //decimal ItemPrice,
    int Quantity
);
