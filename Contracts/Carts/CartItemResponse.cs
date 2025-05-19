namespace e_commerce.Contracts.Carts;

public record CartItemResponse(
    int Id,
    int ProductId,
    string Name,
    string Price,
    string Description,
    int Quantity,
    List<ProductImagesResponse?> ProductImages
);
