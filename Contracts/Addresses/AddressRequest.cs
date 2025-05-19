namespace e_commerce.Contracts.Addresses;

public record AddressRequest(
    string Street,
    string City,
    string State,
    string PostalCode
);
