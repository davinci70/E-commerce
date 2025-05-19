using e_commerce.Contracts.Common;

namespace e_commerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("{Id}")]
    [HasPermission(Permissions.GetProducts)]
    public async Task<IActionResult> Get([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _productService.GetAsync(Id, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }
    
    [HttpGet("")]
    [HasPermission(Permissions.GetProducts)]
    public async Task<IActionResult> GetAll([FromQuery] RequestFilters filters, CancellationToken cancellationToken)
    {
        var result = await _productService.GetAllAsync(filters, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddProducts)]
    public async Task<IActionResult> Add([FromForm] ProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.AddAsync(request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new {id = result.Value.Id}, result.Value)
            : result.ToProplem();
    }

    [HttpPut("{Id}")]
    [HasPermission(Permissions.UpdateProducts)]
    public async Task<IActionResult> Update([FromRoute] int Id,[FromForm] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.UpdateAsync(Id, request, cancellationToken);

        return result.IsSuccess
            ? NoContent() 
            : result.ToProplem();
    }
    
    [HttpPut("{Id}/toggle-status")]
    [HasPermission(Permissions.UpdateProducts)]
    public async Task<IActionResult> Toggle([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _productService.ToggleAsync(Id, cancellationToken);

        return result.IsSuccess
            ? NoContent() 
            : result.ToProplem();
    }
}
