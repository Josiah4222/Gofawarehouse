using Microsoft.AspNetCore.Identity;

namespace Gofabackend.Models
{
    public class User : IdentityUser<string> // Use IdentityUser<string> for custom Id type
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}