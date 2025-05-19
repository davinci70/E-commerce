using e_commerce.Contracts.Reviews;

namespace e_commerce.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReviewController(IReviewService reviewService) : ControllerBase
{
    private readonly IReviewService _reviewService = reviewService;

    [HttpGet("{Id}")]
    [HasPermission(Permissions.GetReviews)]
    public async Task<IActionResult> Get([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _reviewService.GetAsync(Id, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddReviews)]
    public async Task<IActionResult> Add([FromBody] ReviewRequest request, CancellationToken cancellationToken)
    {
        var result = await _reviewService.AddAsync(User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new {id = result.Value.Id}, result.Value)
            : result.ToProplem();
    }

    [HttpPut("{Id}")]
    [HasPermission(Permissions.UpdateReviews)]
    public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateReviewRequest request, CancellationToken cancellationToken)
    {
        var result = await _reviewService.UpdateAsync(Id, User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess
            ? NoContent() 
            : result.ToProplem();
    }
    
    [HttpDelete("{Id}")]
    [HasPermission(Permissions.DeleteReviews)]
    public async Task<IActionResult> Delete([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _reviewService.DeleteAsync(Id, User.GetUserId()!, cancellationToken);

        return result.IsSuccess
            ? NoContent() 
            : result.ToProplem();
    }

    [HttpGet("customer-reviews")]
    [HasPermission(Permissions.GetReviews)]
    public async Task<IActionResult> GetUserReviews(CancellationToken cancellationToken)
    {
        var result = await _reviewService.GetUserReviewsAsync(User.GetUserId()!, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }
    
    [HttpGet("{productId}/product-reviews")]
    [HasPermission(Permissions.GetReviews)]
    public async Task<IActionResult> GetProductReviews(int productId, CancellationToken cancellationToken)
    {
        var result = await _reviewService.GetProductReviewsAsync(productId, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }
}
