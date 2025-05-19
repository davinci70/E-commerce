﻿
namespace e_commerce.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = DefaultRoles.Admin)]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _userService.GetAllAsync(cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await _userService.GetAsync(id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProplem();
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userService.AddAsync(request, cancellationToken);

        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { result.Value.Id }, result.Value) : result.ToProplem();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userService.UpdateAsync(id, request, cancellationToken);

        return result.IsSuccess ? NoContent() : result.ToProplem();
    }

    [HttpPut("{id}/toggle-status")]
    public async Task<IActionResult> Update([FromRoute] string id, CancellationToken cancellationToken)
    {
        var result = await _userService.ToggleStatusAsync(id);

        return result.IsSuccess ? NoContent() : result.ToProplem();
    }

    [HttpPut("{id}/unlock")]
    public async Task<IActionResult> Unlock([FromRoute] string id, CancellationToken cancellationToken)
    {
        var result = await _userService.Unlock(id);

        return result.IsSuccess ? NoContent() : result.ToProplem();
    }
}
