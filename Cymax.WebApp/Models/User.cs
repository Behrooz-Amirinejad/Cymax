using Microsoft.AspNetCore.Identity;

namespace Cymax.WebApp.Models;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
