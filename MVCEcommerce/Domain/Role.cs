using Microsoft.AspNetCore.Identity;

namespace MVCEcommerce.Domain;

public class Role : IdentityRole<Guid>
{
    public required string DisplayName { get; set; }
}
