
namespace e_commerce.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsDisabled { get; set; }
    public DateTime CreatedOn { get; set; }

    public List<RefreshToken> RefreshTokens { get; set; } = [];
    public List<Address> Addresses { get; set; } = [];
}
