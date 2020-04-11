using AutoMapper;
using profile.data.DTO;
using profile.data.Enums;
using profile.data.ProfileModels;

namespace profile.api.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<NewProfileDTO, ProfileModel> ();
            CreateMap<ProfileModel,ProfileDTO>();

            //enums
            CreateMap<GenderEnum,string>().ConvertUsing(x => x.ToString());
            CreateMap<ProfileVisibilityEnum,string>().ConvertUsing(x => x.ToString());
            CreateMap<InstrumentEnum, string>().ConvertUsing(x => x.ToString());
        }
    }
}