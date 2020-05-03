using AutoMapper;
using profile.data.BlockingModels;
using profile.data.DTO;
using profile.data.Enums;
using profile.data.FollowersModels;
using profile.data.ProfileModels;
using profile.data.ProfileModels.Profile;

namespace profile.api.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile() {
            //-----Profile-----
            CreateMap<ProfileModel, ProfileModel>();

            CreateMap<NewProfileDTO, ProfileModel>();
            CreateMap<ProfileModel, ProfileDTO>();

            CreateMap<GearModel, ProfileGearModel>();
            CreateMap<ProfileGearModel, GearModel>();

            CreateMap<ExperienceModel, ProfileExperienceModel>();
            CreateMap<ProfileExperienceModel, ExperienceModel>();

            CreateMap<AvailabilityDTO, AvailabilityModel>();
            CreateMap<AvailabilityModel, AvailabilityDTO>();

            CreateMap<AvailabilityModel, ProfileAvailabilityModel>();
            CreateMap<ProfileAvailabilityModel, AvailabilityModel>();

            //enums
            CreateMap<GenderEnum, string>().ConvertUsing(x => x.ToString());
            CreateMap<ProfileVisibilityEnum, string>().ConvertUsing(x => x.ToString());
            CreateMap<InstrumentEnum, string>().ConvertUsing(x => x.ToString());
            CreateMap<DayEnum, string>().ConvertUsing(x => x.ToString());

            //-----Followers-----
            CreateMap<FollowersDTO, FollowersModel>();
            CreateMap<FollowersModel, FollowersDTO>();

            //Blocking
            CreateMap<BlockedDTO, BlockedModel>();
            CreateMap<BlockedModel, BlockedDTO>();
        }
    }
}