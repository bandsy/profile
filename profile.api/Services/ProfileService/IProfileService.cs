using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService
{

    //TODO change model when new one is done
    public interface IProfileService
    {
         Task<List<ProfileModel>> GetAllProfiles();
         Task<ProfileModel> GetProfileById(int id);
         Task<ProfileModel> GetProfileByEmail(string email);
    }
}