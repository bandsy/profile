using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.DTO;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService {

    public interface IProfileService {
        Task<List<ProfileDTO>> GetAllProfiles ();
        Task<ProfileDTO> GetProfileById (int m_ID);
        Task<ProfileDTO> GetProfileByEmail (string email);
        Task<ProfileDTO> GetProfileByUsername (string username);
        Task<int> AddNewProfile (NewProfileDTO newProfile);
        Task<bool> DeleteProfile (int m_ID);
    }
}