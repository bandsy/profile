using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.api.Services.ProfileService;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Controllers.ProfileControllers {
    [ApiController]
    [Route ("/api/[controller]")]
    public class ProfileController : ControllerBase {

        public readonly IProfileService _profileService;

        public ProfileController (IProfileService profileService) {
            _profileService = profileService;
        }

        [HttpGet]
        [Route ("[action]")]
        public async Task<List<ProfileDTO>> Profiles () {
            var profiles = await _profileService.GetAllProfiles ();

            return profiles;
        }

        [HttpGet]
        [Route ("[action]")]
        public async Task<ProfileDTO> GetProfileById ([FromQuery] int m_ID) {
            var profile = await _profileService.GetProfileById (m_ID);

            return profile;
        }

        [HttpGet]
        [Route ("[action]")]
        public async Task<ProfileDTO> GetProfileByEmail ([FromQuery] string email) {
            var profile = await _profileService.GetProfileByEmail (email);

            return profile;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ProfileDTO> GetProfileByUsername([FromQuery] string username){
            var profile = await _profileService.GetProfileByUsername(username);

            return profile;
        }

        [HttpPost]
        [Route ("[action]")]
        public async Task<int> CreateNewProfile ([FromBody] NewProfileDTO newProfile) {
            var profileAdded = await _profileService.AddNewProfile (newProfile);

            return profileAdded;
        }
    }
}