using Microsoft.AspNetCore.Identity;

namespace MVCEcommerce.Domain;

public enum Genders
{
    Male, Female
}

public class User : IdentityUser <Guid>
{
    public required string GivenName { get; set; }
    public required DateTime Date { get; set; }
    public required Genders Gender { get; set; }

  
}
