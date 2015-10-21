using Newtonsoft.Json;

namespace Folke.Social.Facebook
{
    public class FacebookData<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
