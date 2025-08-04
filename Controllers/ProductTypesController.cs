namespace e_commerce.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = DefaultRoles.Admin)]
public class ProductTypesController(IProductTypeService productTypeService) : ControllerBase
{
    private readonly IProductTypeService _productTypeService = productTypeService;

    [HttpGet("")]
    public async Task<IActionResult> GetAll([FromQuery] RequestFilters filters, CancellationToken cancellationToken)
    {
        return Ok(await _productTypeService.GetAllAsync(filters, cancellationToken));
    }
    
    [HttpGet("Lockup")]
    public async Task<IActionResult> GetLockup(CancellationToken cancellationToken)
    {
        return Ok(await _productTypeService.LockupAsync(cancellationToken));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(int Id, CancellationToken cancellationToken)
    {
        var resut = await _productTypeService.GetAsync(Id, cancellationToken);

        return resut.IsSuccess
            ? Ok(resut.Value)
            : resut.ToProplem();
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromForm] ProductTypeRequest request, CancellationToken cancellationToken)
    {
        var result = await _productTypeService.AddAsync(request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new { id = result.Value.Id }, result.Value)
            : result.ToProplem();
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update(int Id,[FromForm]  ProductTypeRequest request, CancellationToken cancellationToken)
    {
        var result = await _productTypeService.UpdateAsync(Id, request, cancellationToken);

        return result.IsSuccess
            ? NoContent() 
            : result.ToProplem();
    }
    
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
    {
        var result = await _productTypeService.DeleteAsync(Id, cancellationToken);

        return result.IsSuccess
            ? NoContent() 
            : result.ToProplem();
    }
}
