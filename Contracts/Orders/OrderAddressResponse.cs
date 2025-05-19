namespace e_commerce.Contracts.Orders;

public record OrderAddressResponse(
    int Id,
    string Street,
    string City,
    string State,
    string PostalCode
);
