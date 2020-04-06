using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.api.Services.ProfileService;
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
        public async Task<List<ProfileModel>> Profiles () {

            var profiles = await _profileService.GetAllProfiles ();

            return profiles;
        }

        [HttpGet]
        [Route ("[action]/{id}")]
        public async Task<ProfileModel> GetProfileById (int id) {
            var profile = await _profileService.GetProfileById(id);

            return profile;
        }

        [HttpGet]
        [Route ("[action]/{email}")]
        public async Task<ProfileModel> GetProfileByEmail (string email) {
            var profile = await _profileService.GetProfileByEmail (email);

            return profile;
        }

    }
}