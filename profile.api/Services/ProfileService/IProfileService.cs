using System.Collections.Generic;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService {
    public interface IProfileService {

        IEnumerable<ProfileModel> GetProfiles ();
        ProfileModel GetProfileByEmail (string email);
    }
}