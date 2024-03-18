using Newtonsoft.Json;

namespace WBAuth.BO
{
    public class LinkedInUserInfo
    {

        [JsonProperty("sub")]
        public string? sub { get; set; }

        [JsonProperty("name")]
        public string? fullName { get; set; }

        [JsonProperty("given_name")]
        public string? firstName { get; set; }

        [JsonProperty("family_name")]
        public string? lastName { get; set; }

        [JsonProperty("picture")]
        public string? picture { get; set; }

        [JsonProperty("locale")]
        public string? locale { get; set; }

        [JsonProperty("email")]
        public string? email { get; set; }

        [JsonProperty("email_verified")]
        public bool emailVerified { get; set; }


    }

}
