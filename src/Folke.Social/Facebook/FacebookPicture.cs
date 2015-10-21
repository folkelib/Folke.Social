using Newtonsoft.Json;

namespace Folke.Social.Facebook
{
    public class FacebookPicture
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}