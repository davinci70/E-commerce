

namespace e_commerce.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AddressesController(IAddressService addressService) : ControllerBase
{
    private readonly IAddressService _addressService = addressService;

    [HttpGet("current-user")]
    public async Task<IActionResult> GetByUserId(CancellationToken cancellationToken)
    {
        return Ok(await _addressService.GetByUserIdAsync(cancellationToken));
    }
    
    [HttpGet("{Id}")]
    [Authorize(Roles = DefaultRoles.Admin)]
    public async Task<IActionResult> Get([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _addressService.GetAsync(Id, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProplem();
    }
    
    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] AddressRequest request, CancellationToken cancellationToken)
    {
        var result = await _addressService.AddAsync(request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new {id = result.Value.Id}, result.Value)
            : result.ToProplem();
    }
    
    [HttpPut("{Id}")]
    public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] AddressRequest request, CancellationToken cancellationToken)
    {
        var result = await _addressService.UpdateAsync(Id, request, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProplem();
    }
    
    [HttpPut("{Id}/toggle-status")]
    public async Task<IActionResult> ToggleStatus([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _addressService.ToggleStatusAsync(Id, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProplem();
    }
}
