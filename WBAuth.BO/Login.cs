using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WBAuth.BO
{
    public class Login
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}



