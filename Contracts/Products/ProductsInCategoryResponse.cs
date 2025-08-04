namespace e_commerce.Contracts.Products;

public record ProductsInCategoryResponse(
    string Name,
    decimal Price,
    decimal Discount,
    string? ThumbnailUrl
);
