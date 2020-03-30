using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profile.api.Connectors.Profile;
using profile.data.ProfileModels;

namespace profile.api.Controllers.ProfileControllers {
    [ApiController]
    [Route ("/api/[controller]")]
    public class ProfileController : ControllerBase {

        public readonly IProfileConnector _profileConnector;

        public ProfileController (IProfileConnector profileConnector) {
            _profileConnector = profileConnector;
        }

        [HttpGet]
        [Route ("[action]")]
        public async Task<IEnumerable<ProfileModel>> Profiles () {

            var profiles = await _profileConnector.GetAllProfiles ();

            return profiles;
        }

        [HttpGet]
        [Route ("[action]/{id}")]
        public async Task<ProfileModel> GetProfileById (int id) {
            var profile = await _profileConnector.GetProfileById (id);

            return profile;
        }

        [HttpGet]
        [Route("[action]/{email}")]
        public async Task<ProfileModel> GetProfileByEmail(string email){
            var profile = await _profileConnector.GetProfileByEmail(email);

            return profile;
        }

    }
}