using System.Collections.Generic;
using System.Threading.Tasks;
using profile.api.Connectors.Profile;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService {
    public class ProfileService : IProfileService {
        public readonly IProfileConnector _profileConnector;

        public ProfileService (IProfileConnector profileConnector) {
            _profileConnector = profileConnector;
        }

        public async Task<List<ProfileModel>> GetAllProfiles () {
            var profiles = await _profileConnector.GetAllProfiles ();

            return profiles;
        }

        public async Task<ProfileModel> GetProfileByEmail (string email) {
            var profile = await _profileConnector.GetProfileByEmail (email);

            return profile;
        }

        public async Task<ProfileModel> GetProfileById (int id) {
            var profile = await _profileConnector.GetProfileById (id);

            return profile;
        }

        public Task<int> AddNewProfile (ProfileDTO newProfile) {
            var profileToAdd = new ProfileModel ();






            var addedProfile = _profileConnector.AddProfile (profileToAdd);

            return addedProfile;
        }
    }
}