using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.FollowersModels;

namespace profile.api.Connectors.Followers {
    public interface IFollowersConnector {
        Task<List<FollowersModel>> GetFollowers(int m_Id);
        Task<int> AddFollower(FollowersModel followersModel);
        Task<int> RemoveFollower(int m_Id, int f_Id);
    }
}