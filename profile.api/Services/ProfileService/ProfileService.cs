using System.Collections.Generic;
using System.Threading.Tasks;
using profile.api.Connectors.Profile;
using profile.api.Services.DTOConverters.ProfileDTOToProfileModel;
using profile.api.Services.LanguageService;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService {
    public class ProfileService : IProfileService {

        public readonly IProfileConnector _profileConnector;
        public readonly ILanguageService _languageService;
        public readonly INewProfileToProfileModelConverter _newProfileToProfileModelConverter;

        public ProfileService (IProfileConnector profileConnector, ILanguageService languageService, INewProfileToProfileModelConverter newProfileToProfileModelConverter) {
            _profileConnector = profileConnector;
            _languageService = languageService;
            _newProfileToProfileModelConverter = newProfileToProfileModelConverter;

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

        public Task<int> AddNewProfile (NewProfileDTO newProfile) {

            //convert dto
            var profileToAdd = _newProfileToProfileModelConverter.ConvertNewProfileDTOToProfileModel (newProfile);

            // call connector to add to db
            var addedProfile = _profileConnector.AddProfile (profileToAdd);

            return addedProfile;
        }
    }
}