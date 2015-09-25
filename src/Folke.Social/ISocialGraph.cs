using System.Collections.Generic;
using System.Threading.Tasks;

namespace Folke.Social
{
    public interface ISocialGraph
    {
        Task<ISocialIdentity> GetIdentityAsync(string userId);
        Task<byte[]> GetPictureAsync(string userId);
        Task<IEnumerable<ISocialIdentity>> GetFriendsAsync(string userId);
    }
}
