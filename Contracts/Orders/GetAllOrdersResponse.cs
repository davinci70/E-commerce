namespace e_commerce.Contracts.Orders;

public record GetAllOrdersResponse(
    int Id,
    string UserId,
    string UserName,
    string UserEmail,
    string UserPhone,
    DateTime OrderDate,
    decimal TotalPrice,
    string status,
    bool IsPaid,
    List<OrderItemResponse> OrderItems,
    OrderAddressResponse ShippingAddress
);
