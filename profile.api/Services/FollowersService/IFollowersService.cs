using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.DTO;

namespace profile.api.Services.FollowersService {
    public interface IFollowersService {
        Task<List<FollowersDTO>> GetFollowers(int m_Id);
        Task<int> GetFollowersCount(int m_Id);
        Task<bool> AddFollower(FollowersDTO followerDto);
        Task<bool> RemoveFollower(FollowersDTO followersDto);
    }
}