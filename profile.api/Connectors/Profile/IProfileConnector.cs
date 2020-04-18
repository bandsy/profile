using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.ProfileModels;

namespace profile.api.Connectors.Profile {
    public interface IProfileConnector {
        Task<List<ProfileModel>> GetAllProfiles ();
        Task<ProfileModel> GetProfileById (int m_ID);
        Task<ProfileModel> GetProfileByEmail (string email);
        Task<ProfileModel> GetProfileByUsername (string username);
        Task<int> AddProfile (ProfileModel profile);
        Task<int> UpdateProfile (ProfileModel profileToUpdate);
        Task<int> DeleteProfile (int m_ID);

    }
}