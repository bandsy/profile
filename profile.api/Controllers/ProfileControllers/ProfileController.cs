using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.api.Services.ProfileService;
using profile.data.DTO;
using profile.data.ProfileModels;
using profile.data.ProfileModels.Profile;

namespace profile.api.Controllers.ProfileControllers {
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProfileController : ControllerBase {

        public readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService) {
            _profileService = profileService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<ProfileDTO>> Profiles() {
            var profiles = await _profileService.GetAllProfiles();

            return profiles;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ProfileDTO> GetProfileById([FromQuery] int id) {
            var profile = await _profileService.GetProfileById(id);

            return profile;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ProfileDTO> GetProfileByEmail([FromQuery] string email) {
            var profile = await _profileService.GetProfileByEmail(email);

            return profile;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ProfileDTO> GetProfileByUsername([FromQuery] string username) {
            var profile = await _profileService.GetProfileByUsername(username);

            return profile;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> CreateNewProfile([FromBody] NewProfileDTO newProfile) {
            var profileAdded = await _profileService.AddNewProfile(newProfile);

            return profileAdded;
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<ProfileDTO> UpdateProfile([FromQuery] int id, [FromBody] NewProfileDTO updatedProfile) {
            var profileUpdated = await _profileService.UpdateProfile(id, updatedProfile);

            return profileUpdated;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ProfileDTO> ClearProfile([FromQuery] int id) {
            var profile = await _profileService.ClearProfile(id);

            return profile;
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<bool> DeleteProfile([FromQuery] int id) {
            var deleted = await _profileService.DeleteProfile(id);

            return deleted;
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<List<ProfileAvailabilityModel>> UpdateAvailability([FromBody] AvailabilityDTO availabilityDTO) {
            var updated = await _profileService.UpdateAvailability(availabilityDTO);

            return updated;
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<List<ProfileGearModel>> UpdateGear([FromBody] GearDTO gearDTO) {
            var updated = await _profileService.UpdateGear(gearDTO);

            return updated;
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<List<ProfileExperienceModel>> UpdateExperience([FromBody] ExperienceDTO experienceDTO) {
            var updated = await _profileService.UpdateExperience(experienceDTO);

            return updated;
        }
    }
}