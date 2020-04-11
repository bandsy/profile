using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService
{

    //TODO change model when new one is done
    public interface IProfileService
    {
         Task<List<ProfileDTO>> GetAllProfiles();
         Task<ProfileDTO> GetProfileById(int id);
         Task<ProfileDTO> GetProfileByEmail(string email);
         Task<int> AddNewProfile(NewProfileDTO newProfile);
    }
}