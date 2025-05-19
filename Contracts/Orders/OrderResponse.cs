namespace e_commerce.Contracts.Orders;

public record OrderResponse(
    int Id,
    string UserId,
    string UserName,
    string UserEmail,
    string UserPhone,
    DateTime OrderDate,
    decimal TotalPrice,
    string status,
    List<OrderItemResponse> OrderItems,
    OrderAddressResponse ShippingAddress
);
