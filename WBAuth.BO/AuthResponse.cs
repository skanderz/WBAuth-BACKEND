using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.BO
{
    public class AuthResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public bool? Is2StepVerificationRequired { get; set; }
        public string? Provider { get; set; }
        public object? Payload { get; set; }
        public string? username { get; set; }
    }
    
}
