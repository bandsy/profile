using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using profile.api.Connectors.Profile;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService {
    public class ProfileService : IProfileService {

        public readonly IProfileConnector _profileConnector;
        public readonly IMapper _mapper;

        public ProfileService (IProfileConnector profileConnector, IMapper mapper) {
            _profileConnector = profileConnector;
            _mapper = mapper;
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

            var profileToAdd = _mapper.Map<ProfileModel> (newProfile);

            var addedProfile = _profileConnector.AddProfile (profileToAdd);

            return addedProfile;
        }
    }
}