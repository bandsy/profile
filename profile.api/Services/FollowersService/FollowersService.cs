using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<FollowersDTO>> GetFollowers(int m_Id) {
            var followers = new List<FollowersDTO>();

            var results = await _followersConnector.GetFollowers(m_Id);

            foreach (var result in results) {
                followers.Add(_mapper.Map<FollowersDTO>(result));
            }

            return followers;
        }

        public async Task<int> GetFollowersCount(int m_Id) {
            var followers = await _followersConnector.GetFollowers(m_Id);

            return followers.Count();
        }
        public async Task<bool> AddFollower(FollowersDTO followerDto) {
            var followerModel = _mapper.Map<FollowersModel>(followerDto);

            var result = await _followersConnector.AddFollower(followerModel);

            return result > 0 ? true : false;
        }

        public async Task<bool> RemoveFollower(FollowersDTO followersDto) {
            var result = await _followersConnector.RemoveFollower(followersDto.m_id, followersDto.f_id);

            return result > 0 ? true : false;
        }
    }
}