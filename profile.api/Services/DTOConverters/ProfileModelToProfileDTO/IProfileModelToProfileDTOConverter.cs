using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.DTOConverters.ProfileModelToProfileDTO
{
    public interface IProfileModelToProfileDTOConverter
    {
         ProfileDTO ConvertProfileModelToProfileDTO(ProfileModel profileModel);
    }
}