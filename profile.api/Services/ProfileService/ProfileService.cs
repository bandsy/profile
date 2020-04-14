using System.Collections.Generic;
using System.Threading.Tasks;
using profile.api.Connectors.Profile;
using profile.api.Services.DTOConverters.NewProfileDTOToProfileModel;
using profile.api.Services.DTOConverters.ProfileModelToProfileDTO;
using profile.api.Services.LanguageService;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService {
    public class ProfileService : IProfileService {

        public readonly IProfileConnector _profileConnector;
        public readonly ILanguageService _languageService;
        public readonly INewProfileToProfileModelConverter _newProfileToProfileModelConverter;
        public readonly IProfileModelToProfileDTOConverter _profileModelToProfileDTOConverter;

        public ProfileService (IProfileConnector profileConnector, ILanguageService languageService, INewProfileToProfileModelConverter newProfileToProfileModelConverter, IProfileModelToProfileDTOConverter profileModelToProfileDTOConverter) {
            _profileConnector = profileConnector;
            _languageService = languageService;
            _newProfileToProfileModelConverter = newProfileToProfileModelConverter;
            _profileModelToProfileDTOConverter = profileModelToProfileDTOConverter;

        }

        public async Task<List<ProfileDTO>> GetAllProfiles () {
            var profileModels = await _profileConnector.GetAllProfiles ();
            var profileDTOs = new List<ProfileDTO> ();

            foreach (var profileModel in profileModels) {
                profileDTOs.Add (_profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO (profileModel));
            }

            return profileDTOs;
        }

        public async Task<ProfileDTO> GetProfileByEmail (string email) {
            var profileModel = await _profileConnector.GetProfileByEmail (email);
            var profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO (profileModel);

            return profileDTO;
        }

        public async Task<ProfileDTO> GetProfileById (int m_ID) {
            var profileModel = await _profileConnector.GetProfileById (m_ID);
            var profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO (profileModel);

            return profileDTO;
        }
        
         public async Task<ProfileDTO> GetProfileByUsername(string username)
        {
            var profileModel = await _profileConnector.GetProfileByUsername(username);
            var profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO(profileModel);

            return profileDTO;
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