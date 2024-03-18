using Newtonsoft.Json;

namespace WBAuth.BO
{
    public class LinkedInToken
    {

        [JsonProperty("access_token")]
        public string? accessToken { get; set; }

        [JsonProperty("expires_in")]
        public int? expiresIn { get; set; }

        [JsonProperty("scope")]
        public string? scope { get; set; }


    }

}
