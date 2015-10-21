using Newtonsoft.Json;

namespace Folke.Social.Facebook
{
    public class FacebookUser : ISocialIdentity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Nickname { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}