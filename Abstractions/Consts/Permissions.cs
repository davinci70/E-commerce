namespace e_commerce.Abstractions.Consts;

public class Permissions
{
    public static string Type { get; } = "permissions";

    public const string GetProductTypes = "ProductTypes:read";
    public const string AddProductTypes = "ProductTypes:add";
    public const string UpdateProductTypes = "ProductTypes:update";
    public const string DeleteProductTypes = "ProductTypes:delete";

    public const string GetCartInfo = "carts:read";
    public const string AddToCart = "carts:add";
    public const string UpdateCart = "carts:update";
    public const string DeleteCart = "carts:delete";

    public const string GetOrderInfo = "orders:read";
    public const string PlaceOrder = "orders:add";
    public const string UpdateOrder = "orders:update";

    public const string CreatePayment = "payments:add";
    public const string Webhook = "payments:webhook";

    public const string GetProducts = "products:read";
    public const string AddProducts = "products:add";
    public const string UpdateProducts = "products:update";

    public const string GetReviews = "reviews:read";
    public const string AddReviews = "reviews:add";
    public const string UpdateReviews = "reviews:update";
    public const string DeleteReviews = "reviews:delete";

    public const string GetWishlists = "wishlists:read";
    public const string AddWishlists = "wishlists:add";
    public const string DeleteWishlists = "wishlists:delete";
    
    public const string GetUsers = "users:read";
    public const string AddUsers = "users:add";
    public const string UpdateUsers = "users:update";

    public static IList<string> GetAllPermissions() =>
    [
        GetProductTypes, AddProductTypes, UpdateProductTypes, DeleteProductTypes,
        GetCartInfo, AddToCart, UpdateCart, DeleteCart,
        GetOrderInfo, PlaceOrder, UpdateOrder,
        CreatePayment, Webhook,
        GetProducts, AddProducts, UpdateProducts,
        GetReviews, AddReviews, UpdateReviews, DeleteReviews,
        GetWishlists, AddWishlists, DeleteWishlists,
        GetUsers, AddUsers, UpdateUsers
    ];
}
