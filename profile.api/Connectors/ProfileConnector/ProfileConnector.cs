using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using profile.api.EntityFramework;
using profile.data.ProfileModels;

namespace profile.api.Connectors.ProfileConnector {
    public class ProfileConnector : IProfileConnector {

        public readonly ProfileApiDbContext _profileApiDbContext;

        public ProfileConnector (ProfileApiDbContext profileConnector) {
            _profileApiDbContext = profileConnector;
        }

        public async Task<List<ProfileModel>> GetAllProfiles () {
            var profiles = await _profileApiDbContext.Profiles.ToListAsync ();

            return profiles;
        }

        public async Task<ProfileModel> GetProfileByEmail (string email) {

            var profile = await _profileApiDbContext.Profiles
                .Include (x => x.ProfilePicture)
                .Include (x => x.Media)
                .Include (x => x.Events)
                .Include (x => x.Experience)
                .Include (x => x.GearModels)
                .FirstOrDefaultAsync (x => x.EmailAddress.Equals (email));

            return profile;
        }
    }
}