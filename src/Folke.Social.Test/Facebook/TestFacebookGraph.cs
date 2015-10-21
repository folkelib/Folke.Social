using Folke.Social.Facebook;
using Microsoft.Framework.Configuration;
using Xunit;

namespace Folke.Social.Test.Facebook
{
    public class TestFacebookGraph
    {
        private readonly FacebookGraph graph;

        public TestFacebookGraph()
        {
            var configurationBuilder = new ConfigurationBuilder("");
            configurationBuilder.AddJsonFile("config.json");
            var configuration = configurationBuilder.Build();
            graph = new FacebookGraph(configuration["facebook:appId"], configuration["facebook:appSecret"]);
        }

        [Fact]
        public async void FacebookGraph_GetIdentityAsync()
        {
            var identity = await graph.GetIdentityAsync("10153051799743005");
            Assert.Equal("Sidoine", identity.FirstName);
            Assert.Equal("De Wispelaere", identity.LastName);
            Assert.Equal("Sidoine De Wispelaere", identity.Nickname);
            Assert.Equal("sidoine@sidoine.net", identity.Email);
        }

        [Fact]
        public async void FacebookGraph_GetPictureAsync()
        {
            var picture = await graph.GetPictureAsync("10153051799743005");
            Assert.NotEmpty(picture);
        }

        [Fact]
        public async void FacebookGraph_GetPictureUrlAsync()
        {
            var picture = await graph.GetPictureUrlAsync("10153051799743005", 200, 200);
            Assert.True(picture.StartsWith("https://"));
        }

        [Fact]
        public async void FacebookGraph_GetFriendsAsync()
        {
            await graph.GetFriendsAsync("10153051799743005");
        }
    }
}
