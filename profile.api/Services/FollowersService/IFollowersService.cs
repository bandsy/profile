using System.Threading.Tasks;
using profile.data.DTO;

namespace profile.api.Services.FollowersService
{
    public interface IFollowersService
    {
          Task<bool> AddFollower(FollowersDTO followerDto);
    }
}