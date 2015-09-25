using Newtonsoft.Json;

namespace Folke.Social.Facebook
{
    public class FacebookFriend : ISocialIdentity
    {
        [JsonIgnore]
        public string FirstName => null;
        [JsonIgnore]
        public string LastName => null;
        [JsonProperty("name")]
        public string Nickname { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}