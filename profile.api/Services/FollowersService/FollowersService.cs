using System.Threading.Tasks;
using AutoMapper;
using profile.api.Connectors.Followers;
using profile.data.DTO;
using profile.data.FollowersModels;

namespace profile.api.Services.FollowersService {
    public class FollowersService : IFollowersService {
        public readonly IMapper _mapper;
        public readonly IFollowersConnector _followersConnector;
        public FollowersService(IMapper mapper, IFollowersConnector followersConnector) {
            _mapper = mapper;
            _followersConnector = followersConnector;
        }
        public async Task<bool> AddFollower(FollowersDTO followerDto) {
            var followerModel = _mapper.Map<FollowersModel>(followerDto);

            var result = await _followersConnector.AddFollower(followerModel);

            return result > 0 ? true : false;
        }
    }
}