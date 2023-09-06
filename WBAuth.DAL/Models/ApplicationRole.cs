using Microsoft.AspNetCore.Identity;

namespace WBAuth.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string? FullName { get; set; }

    }
}

