namespace e_commerce.Contracts.Products;

public record ProductResponse(
    int Id,
    string Name,
    int ProductTypeId,
    string Description,
    string SmallDescription,
    decimal Price,
    decimal Discount,
    int StockQuantity,
    List<ProductImagesResponse> ProductImages
);
