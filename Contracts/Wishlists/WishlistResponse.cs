namespace e_commerce.Contracts.Wishlists;

public record WishlistResponse(
    int Id,
    string UserId,
    List<WishlistItemsResponse> WishlistItems
);
