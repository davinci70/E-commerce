namespace e_commerce.Contracts.Addresses;

public record AddressResponse(
    int Id,
    string Street,
    string City,
    string State,
    string PostalCode
);
