
using e_commerce.Services.Service;

namespace e_commerce.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, ApplicationUser>()
           .Map(dest => dest.UserName, src => src.Email);

        config.NewConfig<(ApplicationUser user, IList<string> roles), UserResponse>()
            .Map(dest => dest, src => src.user)
            .Map(dest => dest.Roles, src => src.roles);

        config.NewConfig<CreateUserRequest, ApplicationUser>()
            .Map(dest => dest.UserName, src => src.Email)
            .Map(dest => dest.EmailConfirmed, src => true);

        config.NewConfig<UpdateUserRequest, ApplicationUser>()
            .Map(dest => dest.UserName, src => src.Email)
            .Map(dest => dest.NormalizedUserName, src => src.Email.ToUpper());

        config.NewConfig<ProductRequest, Product>()
            .Ignore(dest => dest.ProductImages);

        config.NewConfig<Product, ProductResponse>()
            .Map(dest => dest.ProductImages, src => src.ProductImages.Adapt<List<ProductImagesResponse>>());

        config.NewConfig<UpdateProductRequest, Product>()
        .Ignore(dest => dest.ProductImages);

        config.NewConfig<CartItem, CartItemResponse>()
            .Map(dest => dest.Name, src => src.Product.Name)
            .Map(dest => dest.Price, src => src.Product.Price)
            .Map(dest => dest.Description, src => src.Product.Description)
            .Map(dest => dest.ProductImages, src => src.Product.ProductImages.Adapt<List<ProductImagesResponse>>());

        config.NewConfig<OrderRequest, Order>()
            .Map(dest => dest.Status, _ => OrderStatus.enOrderStatus.Pending);

        config.NewConfig<OrderItem, OrderItemResponse>()
            .Map(dest => dest.ItemName, src => src.Product.Name);

        config.NewConfig<Order, OrderResponse>()
            .Map(dest => dest.UserId, src => src.CreatedById)
            .Map(dest => dest.UserEmail, src => src.CreatedBy.Email)
            .Map(dest => dest.UserPhone, src => src.CreatedBy.PhoneNumber)
            .Map(dest => dest.UserName, src => $"{src.CreatedBy.FirstName} {src.CreatedBy.LastName}")
            .Map(dest => dest.OrderDate, src => src.CreatedOn)
            .Map(dest => dest.ShippingAddress, src => src.ShippingAddress);
        
        config.NewConfig<Order, GetAllOrdersResponse>()
            .Map(dest => dest.UserId, src => src.CreatedById)
            .Map(dest => dest.UserEmail, src => src.CreatedBy.Email)
            .Map(dest => dest.UserPhone, src => src.CreatedBy.PhoneNumber)
            .Map(dest => dest.UserName, src => $"{src.CreatedBy.FirstName} {src.CreatedBy.LastName}")
            .Map(dest => dest.OrderDate, src => src.CreatedOn)
            .Map(dest => dest.IsPaid, src => src.Payment != null && src.Payment.IsPaid)
            .Map(dest => dest.ShippingAddress, src => src.ShippingAddress);

        config.NewConfig<Review, ReviewResponse>()
            .Map(dest => dest.UserId, src => src.CreatedById);

        config.NewConfig<WishlistItem, WishlistItemsResponse>()
            .Map(dest => dest.ImageUrl, src => src.Product.ProductImages.Select(x => x.ImageUrl).FirstOrDefault());
    }
}
