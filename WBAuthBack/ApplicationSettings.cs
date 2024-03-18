namespace WBAuth.Back
{
    public class ApplicationSettings
    {
        public string? JWT_Secret { get; set; }
        public string? Client_URL { get; set; }

        public string Secret { get; set; }
        public string GoogleClientId { get; set; }

        public long FacebookAppId { get; set; }
        public string FacebookSecret { get; set; }

        public long LinkedInAppId { get; set; }
        public string LinkedInSecret { get; set; }

    }

}