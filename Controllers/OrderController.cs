
namespace e_commerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpGet("{Id}")]
    [HasPermission(Permissions.GetOrderInfo)]
    public async Task<IActionResult> Get(int Id, CancellationToken cancellationToken)
    {
        var result = await _orderService.GetByIdAsync(Id, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }
    
    [HttpGet("customer-orders")]
    [HasPermission(Permissions.GetOrderInfo)]
    public async Task<IActionResult> GetByUserId(CancellationToken cancellationToken) =>
        Ok(await _orderService.GetByUserIdAsync(User.GetUserId()!, cancellationToken));


    [HttpPost("")]
    [HasPermission(Permissions.PlaceOrder)]
    public async Task<IActionResult> Add(OrderRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderService.AddAsync(User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new { id = result.Value.Id }, result.Value)
            : result.ToProplem();
    }

    [HttpPut("{Id}")]
    [HasPermission(Permissions.UpdateOrder)]
    public async Task<IActionResult> Update(int Id, OrderRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderService.UpdateAsync(Id, User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProplem();
    }

    [HttpPut("{Id}/toggle-status")]
    [HasPermission(Permissions.UpdateOrder)]
    public async Task<IActionResult> ToggleStatus([FromRoute] int Id, OrderStatus.enOrderStatus enOrderStatus, CancellationToken cancellationToken)
    {
        var result = await _orderService.ToggleStatusAsync(Id, User.GetUserId()!, enOrderStatus, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProplem();
    }
}
