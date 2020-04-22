using System.Threading.Tasks;
using profile.data.FollowersModels;

namespace profile.api.Connectors.Followers
{
    public interface IFollowersConnector
    {
        Task<int> AddFollower(FollowersModel followersModel);
    }
}