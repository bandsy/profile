using System.Threading.Tasks;
using AutoMapper;
using profile.api.Services.LanguageService;
using profile.data.DTO;
using profile.data.ProfileModels;
using profile.data.ProfileModels.Profile;

namespace profile.api.Services.DTOConverters.ProfileModelToProfileDTO {
    public class ProfileModelToProfileDTOConverter : IProfileModelToProfileDTOConverter {
        public readonly IMapper _mapper;
        public readonly ILanguageService _languageService;
        public ProfileModelToProfileDTOConverter(IMapper mapper, ILanguageService languageService) {
            _mapper = mapper;
            _languageService = languageService;
        }

        public ProfileDTO ConvertProfileModelToProfileDTO(ProfileModel profileModel) {
            //map base properties
            var profileDTO = _mapper.Map<ProfileDTO>(profileModel);

            //map language iso codes to diaplaye names 
            profileDTO.Languages = _languageService.GetLanguageNames(profileModel.Languages);

            //map avaliability
            foreach (var avaliability in profileModel.Availability) {
                profileDTO.Availability.Add(_mapper.Map<ProfileAvailabilityModel>(avaliability));
            }

            //TODO additional calls to handle media & listings

            return profileDTO;
        }
    }
}