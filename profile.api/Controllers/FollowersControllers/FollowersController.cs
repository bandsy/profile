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

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> AddFollower([FromBody] FollowersDTO followersDto) {
            var result = await _followersService.AddFollower(followersDto);

            return result;
        }
    }
}