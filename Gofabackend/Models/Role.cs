using Microsoft.AspNetCore.Identity;

namespace Gofabackend.Models
{
    public class Role : IdentityRole<string> // Use IdentityRole<string> for custom Id type
    {
        // Add any additional properties if needed
    }
}