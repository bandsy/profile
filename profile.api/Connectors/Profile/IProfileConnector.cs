using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.ProfileModels;

namespace profile.api.Connectors.Profile {
    public interface IProfileConnector {
        Task<List<ProfileModel>> GetAllProfiles ();
        Task<ProfileModel> GetProfileById(int id);
        Task<ProfileModel> GetProfileByEmail(string email);
    }
}