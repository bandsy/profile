using System.Collections.Generic;
using profile.data.ProfileModels;

namespace profile.api.Services.ProfileService {
    public class ProfileService : IProfileService {

        public IEnumerable<ProfileModel> GetProfiles () {
            throw new System.NotImplementedException ();
        }
        public ProfileModel GetProfileByEmail (string email) {
            throw new System.NotImplementedException ();
        }

    }
}