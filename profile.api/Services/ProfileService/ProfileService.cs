using System.Collections.Generic;
using System.Threading.Tasks;
using profile.api.Connectors.Profile;
using profile.api.Services.DTOConverters.NewProfileDTOToProfileModel;
using profile.api.Services.DTOConverters.ProfileModelToProfileDTO;
using profile.api.Services.LanguageService;
using profile.data.DTO;
using profile.data.Enums;
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

        public async Task<ProfileDTO> GetProfileByUsername (string username) {
            var profileModel = await _profileConnector.GetProfileByUsername (username);
            var profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO (profileModel);

            return profileDTO;
        }

        public async Task<int> AddNewProfile (NewProfileDTO newProfile) {
            //convert dto
            var profileToAdd = _newProfileToProfileModelConverter.ConvertNewProfileDTOToProfileModel (newProfile);

            // call connector to add to db
            var addedProfile = await _profileConnector.AddProfile (profileToAdd);

            return addedProfile;
        }

        public async Task<ProfileDTO> UpdateProfile (int m_ID, NewProfileDTO updatedProfile) {
            var profileDTO = new ProfileDTO ();
            var profileToUpdate = await _profileConnector.GetProfileById (m_ID);

            var profile = _newProfileToProfileModelConverter.ConvertNewProfileDTOToProfileModel (updatedProfile);
            profile.Id = profileToUpdate.Id;

            var result = await _profileConnector.UpdateProfile (profile);

            if (result != 0) {
                profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO (profile);
            }

            return profileDTO;
        }

        public async Task<ProfileDTO> ClearProfile (int m_ID) {
            var profileDTO = new ProfileDTO ();
            var profileToClear = await _profileConnector.GetProfileById (m_ID);

            profileToClear.ProfileVisibility = ProfileVisibilityEnum.none;
            profileToClear.Bio = "";
            profileToClear.Languages = new List<string> ();
            profileToClear.Events = new List<EventsModel> ();
            profileToClear.Experience = new List<ExperienceModel> ();
            profileToClear.GearModels = new List<GearModel> ();

            var result = await _profileConnector.UpdateProfile (profileToClear);

            if (result != 0) {
                profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO (profileToClear);
            }

            return profileDTO;

        }

        public async Task<bool> DeleteProfile (int m_ID) {
            var result = await _profileConnector.DeleteProfile (m_ID);

            return result != 0 ? true : false;

        }

    }
}