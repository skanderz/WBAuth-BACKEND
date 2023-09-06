using Microsoft.AspNetCore.Identity;

namespace WBAuth.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? FullName { get; set; }

    }
}




