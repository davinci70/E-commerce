namespace e_commerce.Contracts.Orders;

public record OrderRequest(
    //decimal TotalPrice,
    //string Status,
    int ShippingAddressId,
    List<OrderItemRequest> OrderItems
);
