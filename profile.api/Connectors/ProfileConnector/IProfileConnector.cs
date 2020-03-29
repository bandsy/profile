using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.ProfileModels;

namespace profile.api.Connectors.ProfileConnector {
    public interface IProfileConnector {

        Task<List<ProfileModel>> GetAllProfiles ();
        Task<ProfileModel> GetProfileByEmail (string email);
    }
}