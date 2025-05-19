namespace e_commerce.Extentions;

public class CurrentUser(IHttpContextAccessor httpContextAccessor)
{
    private  readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string UserId => _httpContextAccessor.HttpContext?.User.GetUserId()!;
}
