using System.Collections.Generic;
using System.Threading.Tasks;

namespace Folke.Social
{
    public interface ISocialGraph
    {
        Task<ISocialIdentity> GetIdentityAsync(string userId);
        Task<byte[]> GetPictureAsync(string userId);
        Task<string> GetPictureUrlAsync(string userId, int width, int height);
        Task<IEnumerable<ISocialIdentity>> GetFriendsAsync(string userId);
        ProviderType Type { get; }
    }
}
