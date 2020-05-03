using Newtonsoft.Json;

namespace Arachne.API.Models.Responses
{
    public class Authentication
    {
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? AccessToken { get; set; }
        [JsonProperty("provider_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProviderName { get; set; }
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? UserId { get; set; }
        [JsonProperty("user_claims", NullValueHandling = NullValueHandling.Ignore)]
        public AuthenticationClaim[]? UserClaims { get; set; }
        [JsonProperty("access_token_secret", NullValueHandling = NullValueHandling.Ignore)]
        public string? AccessTokenSecret { get; set; }
        [JsonProperty("authentication_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? AuthenticationToken { get; set; }
        [JsonProperty("expires_on", NullValueHandling = NullValueHandling.Ignore)]
        public string? ExpiresOn { get; set; }
        [JsonProperty("id_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdToken { get; set; }
        [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? RefreshToken { get; set; }
    }

    public class AuthenticationClaim
    {
        [JsonProperty("typ")]
        public string? Type { get; set; }
        [JsonProperty("val")]
        public string? Value { get; set; }
    }
}