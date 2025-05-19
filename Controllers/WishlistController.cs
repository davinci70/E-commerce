
using e_commerce.Contracts.Wishlists;

namespace e_commerce.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WishlistController(IWishlistService wishlistService) : ControllerBase
{
    private readonly IWishlistService _wishlistService = wishlistService;

    [HttpGet("customer-wishlist")]
    [HasPermission(Permissions.GetWishlists)]
    public async Task<IActionResult> GetUserWishlist(CancellationToken cancellationToken)
    {
        var result = await _wishlistService.GetByCustomerIdAsync(User.GetUserId()!, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddWishlists)]
    public async Task<IActionResult> Add(WishlistRequest request, CancellationToken cancellationToken)
    {
        var result = await _wishlistService.AddAsync(User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetUserWishlist), new {id = result.Value.Id}, result.Value)
            : result.ToProplem();
    }

    [HttpDelete("{ItemId}")]
    [HasPermission(Permissions.DeleteWishlists)]
    public async Task<IActionResult> RemoveItem(int ItemId, CancellationToken cancellationToken)
    {
        var result = await _wishlistService.RemoveItemAsync(ItemId, User.GetUserId()!, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProplem();
    }
    
    [HttpDelete("")]
    [HasPermission(Permissions.DeleteWishlists)]
    public async Task<IActionResult> Clear(CancellationToken cancellationToken)
    {
        var result = await _wishlistService.ClearAsync(User.GetUserId()!, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProplem();
    }
}
