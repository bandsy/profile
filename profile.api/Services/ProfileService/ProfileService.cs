using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using profile.api.Connectors.Profile;
using profile.api.Services.AgeService;
using profile.api.Services.DTOConverters.NewProfileDTOToProfileModel;
using profile.api.Services.DTOConverters.ProfileModelToProfileDTO;
using profile.api.Services.LanguageService;
using profile.data.DTO;
using profile.data.Enums;
using profile.data.ProfileModels;
using profile.data.ProfileModels.Profile;

namespace profile.api.Services.ProfileService {
    public class ProfileService : IProfileService {

        public readonly IProfileConnector _profileConnector;
        public readonly ILanguageService _languageService;
        public readonly INewProfileToProfileModelConverter _newProfileToProfileModelConverter;
        public readonly IProfileModelToProfileDTOConverter _profileModelToProfileDTOConverter;

        public readonly IAgeService _ageService;
        public readonly IMapper _mapper;

        public ProfileService(IProfileConnector profileConnector, ILanguageService languageService, INewProfileToProfileModelConverter newProfileToProfileModelConverter, IProfileModelToProfileDTOConverter profileModelToProfileDTOConverter,
            IAgeService ageService,
            IMapper mapper) {
            _profileConnector = profileConnector;
            _languageService = languageService;
            _newProfileToProfileModelConverter = newProfileToProfileModelConverter;
            _profileModelToProfileDTOConverter = profileModelToProfileDTOConverter;
            _ageService = ageService;
            _mapper = mapper;

        }

        public async Task<List<ProfileDTO>> GetAllProfiles() {
            var profileModels = await _profileConnector.GetAllProfiles();
            var profileDTOs = new List<ProfileDTO>();

            foreach (var profileModel in profileModels) {
                profileDTOs.Add(_profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO(profileModel));
            }

            return profileDTOs;
        }

        public async Task<ProfileDTO> GetProfileByEmail(string email) {
            var profileModel = await _profileConnector.GetProfileByEmail(email);
            var profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO(profileModel);

            return profileDTO;
        }

        public async Task<ProfileDTO> GetProfileById(int m_ID) {
            var profileModel = await _profileConnector.GetProfileById(m_ID);
            var profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO(profileModel);

            return profileDTO;
        }

        public async Task<ProfileDTO> GetProfileByUsername(string username) {
            var profileModel = await _profileConnector.GetProfileByUsername(username);
            var profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO(profileModel);

            return profileDTO;
        }

        public async Task<bool> AddNewProfile(NewProfileDTO newProfile) {
            //convert dto
            var profileToAdd = _newProfileToProfileModelConverter.ConvertNewProfileDTOToProfileModel(newProfile);

            // call connector to add to db
            var result = await _profileConnector.AddProfile(profileToAdd);

            return result != 0 ? true : false;
        }

        public async Task<ProfileDTO> UpdateProfile(int m_ID, NewProfileDTO updatedProfile) {
            var profileDTO = new ProfileDTO();

            var profile = await _profileConnector.GetProfileById(m_ID);

            if (profile != null) {

                //map properties
                profile.Forename = updatedProfile.Forename;
                profile.Surname = updatedProfile.Surname;
                profile.EmailAddress = updatedProfile.EmailAddress;
                profile.Username = updatedProfile.Username;
                profile.ProfileVisibility = updatedProfile.ProfileVisibility;
                profile.Gender = updatedProfile.Gender;
                profile.DateOfBirth = updatedProfile.DateOfBirth;
                profile.Age = _ageService.CalculateAge(updatedProfile.DateOfBirth);
                profile.Bio = updatedProfile.Bio;
                profile.PhoneNumber = updatedProfile.PhoneNumber;
                profile.Languages = _languageService.GetIsoCodes(updatedProfile.Languages);

                var result = await _profileConnector.UpdateProfile(profile);

                if (result != 0) {
                    profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO(profile);
                }
            }

            return profileDTO;
        }

        public async Task<ProfileDTO> ClearProfile(int m_ID) {
            var profileDTO = new ProfileDTO();
            var profileToClear = await _profileConnector.GetProfileById(m_ID);

            profileToClear.ProfileVisibility = ProfileVisibilityEnum.none;
            profileToClear.Bio = "";
            profileToClear.Languages = new List<string>();
            profileToClear.Events = new List<EventsModel>();
            profileToClear.Experience = new List<ExperienceModel>();
            profileToClear.GearModels = new List<GearModel>();

            var result = await _profileConnector.UpdateProfile(profileToClear);

            if (result != 0) {
                profileDTO = _profileModelToProfileDTOConverter.ConvertProfileModelToProfileDTO(profileToClear);
            }

            return profileDTO;

        }

        public async Task<bool> DeleteProfile(int m_ID) {
            var result = await _profileConnector.DeleteProfile(m_ID);

            return result != 0 ? true : false;

        }

        public async Task<List<ProfileAvailabilityModel>> UpdateAvailability(AvailabilityDTO availabilityDTO) {
            var result = 0;
            var profileAvailability = new List<ProfileAvailabilityModel>();
            var profile = await _profileConnector.GetProfileById(availabilityDTO.m_ID);

            if (profile != null) {

                if (profile.Availability != null) {

                    profile.Availability.Clear();
                    profile.Availability.AddRange(availabilityDTO.Availabilities);

                } else {
                    profile.Availability = availabilityDTO.Availabilities;
                }

                result = await _profileConnector.UpdateProfile(profile);

            }

            if (result != 0) {
                foreach (var availability in profile.Availability) {
                    profileAvailability.Add(_mapper.Map<ProfileAvailabilityModel>(availability));
                }
            }

            return profileAvailability;
        }
    }
}