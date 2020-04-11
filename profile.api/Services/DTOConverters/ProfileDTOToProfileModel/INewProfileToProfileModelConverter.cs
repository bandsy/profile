using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.DTOConverters.ProfileDTOToProfileModel
{
    public interface INewProfileToProfileModelConverter
    {
         ProfileModel ConvertNewProfileDTOToProfileModel(NewProfileDTO newProfile);
    }
}