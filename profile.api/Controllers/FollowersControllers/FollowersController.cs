using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.api.Services.FollowersService;
using profile.data.DTO;
using profile.data.FollowersModels;

namespace profile.api.Controllers.FollowersControllers {
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class FollowersController : ControllerBase {

        public readonly IFollowersService _followersService;

        public FollowersController(IFollowersService followersService) {
            _followersService = followersService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<FollowersDTO>> GetFollowers([FromQuery] int id) {
            var followers = await _followersService.GetFollowers(id);

            return followers;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<int> GetFollowersCount([FromQuery] int id) {
            var followersCount = await _followersService.GetFollowersCount(id);

            return followersCount;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> Follow([FromBody] FollowersDTO followersDto) {
            var result = await _followersService.AddFollower(followersDto);

            return result;
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<bool> Unfollow([FromBody] FollowersDTO followersDto) {
            var result = await _followersService.RemoveFollower(followersDto);

            return result;
        }
    }
}