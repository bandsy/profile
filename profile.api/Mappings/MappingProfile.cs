using AutoMapper;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<ProfileDTO, ProfileModel> ();
        }
    }
}