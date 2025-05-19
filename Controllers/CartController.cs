
namespace e_commerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController(ICartService cartService) : ControllerBase
{
    private readonly ICartService _cartService = cartService;

    [HttpGet("customer-cart")]
    [HasPermission(Permissions.GetCartInfo)]
    public async Task<IActionResult> GetByCustomerId(CancellationToken cancellationToken)
    {
        var result = await _cartService.GetByCustomerIdAsync(User.GetUserId()!, cancellationToken);

        return result.IsSuccess 
            ? Ok(result.Value)
            : result.ToProplem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddToCart)]
    public async Task<IActionResult> Add([FromBody] CartRequest request, CancellationToken cancellationToken)
    {
        var result = await _cartService.AddAsync(User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetByCustomerId), new { id = result.Value.Id }, result.Value)
            : result.ToProplem();
    }

    [HttpDelete("{itemId}")]
    [HasPermission(Permissions.DeleteCart)]
    public async Task<IActionResult> DeleteItem([FromRoute] int itemId, CancellationToken cancellationToken)
    {
        var result = await _cartService.RemoveItemAsync(User.GetUserId()!, itemId, cancellationToken);

        return result.IsSuccess
            ? NoContent() 
            : result.ToProplem();
    }

    [HttpDelete("")]
    [HasPermission(Permissions.DeleteCart)]
    public async Task<IActionResult> Clear(CancellationToken cancellationToken)
    {
        var result = await _cartService.ClearAsync(User.GetUserId()!, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProplem();
    }
}
