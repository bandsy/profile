using AutoMapper;
using profile.data.DTO;
using profile.data.Enums;
using profile.data.ProfileModels;
using profile.data.ProfileModels.Profile;

namespace profile.api.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<NewProfileDTO, ProfileModel>();
            CreateMap<ProfileModel, ProfileDTO>();
            CreateMap<GearModel, ProfileGearModel>();
            CreateMap<ExperienceModel, ProfileExperienceModel>();

            //enums
            CreateMap<GenderEnum, string>().ConvertUsing(x => x.ToString());
            CreateMap<ProfileVisibilityEnum, string>().ConvertUsing(x => x.ToString());
            CreateMap<InstrumentEnum, string>().ConvertUsing(x => x.ToString());
        }
    }
}