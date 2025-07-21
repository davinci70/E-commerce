namespace e_commerce.Contracts.ProductTypes;

public record ProductTypeRequest(
    string Title,
    IFormFile ImageUrl
);
