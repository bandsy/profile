using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.DTOConverters.NewProfileDTOToProfileModel
{
    public interface INewProfileToProfileModelConverter
    {
         ProfileModel ConvertNewProfileDTOToProfileModel(NewProfileDTO newProfile);
    }
}