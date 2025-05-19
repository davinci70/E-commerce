namespace e_commerce.Contracts.Wishlists;

public record WishlistItemsResponse(
    int ProductId,
    string ProductName,
    decimal ProductPrice,
    decimal ProductDiscount,
    string ImageUrl
);
