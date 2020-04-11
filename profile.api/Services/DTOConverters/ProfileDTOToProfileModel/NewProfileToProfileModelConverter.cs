using System;
using AutoMapper;
using profile.api.Services.LanguageService;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.DTOConverters.ProfileDTOToProfileModel {
    public class NewProfileToProfileModelConverter : INewProfileToProfileModelConverter {
        public readonly IMapper _mapper;
        private readonly ILanguageService _languageService;

        public NewProfileToProfileModelConverter (IMapper mapper, ILanguageService languageService) {
            _mapper = mapper;
            _languageService = languageService;
        }

        public ProfileModel ConvertNewProfileDTOToProfileModel (NewProfileDTO newProfile) {
            //map base details
            var profileModel = _mapper.Map<ProfileModel> (newProfile);

            //get iso codes for languages 
            profileModel.Languages = _languageService.GetIsoCodes (newProfile.Languages);

            throw new NotImplementedException ();
        }
    }
}