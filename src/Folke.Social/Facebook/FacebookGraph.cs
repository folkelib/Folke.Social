using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Folke.Social.Facebook
{
    public class FacebookGraph : ISocialGraph, IDisposable
    {
        private readonly HttpClient client;
        private readonly string appId;
        private readonly string appSecret;
        
        private string token;

        public FacebookGraph(string appId, string appSecret)
        {
            this.appId = appId;
            this.appSecret = appSecret;
            client = new HttpClient();
        }

        public async Task<ISocialIdentity> GetIdentityAsync(string userId)
        {
            return await GetAsync<FacebookUser>(userId, "name,id,first_name,last_name,email");
        } 

        public Task<byte[]> GetPictureAsync(string userId)
        {
            return GetAsync(userId + "/picture");
        }

        public async Task<T> GetAsync<T>(string path, string fields = null)
        {
            var url = "https://graph.facebook.com/" + path + "?access_token=" + Uri.EscapeUriString(await GetAppToken());
            if (fields != null)
                url += "&fields=" + fields;
            var text = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(text);
        }

        public async Task<IEnumerable<ISocialIdentity>> GetFriendsAsync(string userId)
        {
            return (await GetAsync<FacebookFriends>($"{userId}/friends")).data;
        }
        
        public async Task<byte[]> GetAsync(string path, string fields = null)
        {
            var url = "https://graph.facebook.com/" + path + "?access_token=" + await GetAppToken();
            if (fields != null)
                url += "&fields=" + fields;
            return await client.GetByteArrayAsync(url);
        }

        public async Task<string> PostAsync(string path, object parameters)
        {
            var url = "https://graph.facebook.com/" + path;
            var queryString = new Dictionary<string, string>();
            var type = parameters.GetType();
            foreach (var parameter in type.GetProperties())
            {
                queryString.Add(parameter.Name, parameter.GetValue(parameters, null).ToString());
            }
            queryString.Add("access_token", await GetAppToken());

            var response = await client.PostAsync(url, new FormUrlEncodedContent(queryString));
            return await response.Content.ReadAsStringAsync();
        }
        
        private async Task<string> GetAppToken()
        {
            if (token == null)
            {
                var url = "https://graph.facebook.com/oauth/access_token?client_id=" + appId + "&client_secret=" + appSecret + "&grant_type=client_credentials";
                var response = await client.GetAsync(url);
                var text = await response.Content.ReadAsStringAsync();
                var variable = "access_token";
                var split = text.Split('=');
                if (split[0] != variable)
                    throw new Exception("Token non reçu");
                token = split[1];
            }
            return token;
        }
        
        public void Dispose()
        {
            client.Dispose();
        }
    }
}