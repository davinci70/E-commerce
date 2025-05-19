namespace e_commerce.Contracts.Products;

public record ProductRequest(
    string Name,
    int ProductTypeId,
    string Description,
    string SmallDescription,
    decimal Price,
    decimal Discount,
    int StockQuantity,
    List<IFormFile>? ProductImages 
);