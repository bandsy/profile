using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using profile.api.EntityFramework;
using profile.data.ProfileModels;

namespace profile.api.Connectors.Profile {
    public class ProfileConnector : IProfileConnector {

        private ProfileApiDbContext _dbContext;

        public ProfileConnector (ProfileApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public List<ProfileModel> GetAllProfiles () {
            var profiles = _dbContext.Set<ProfileModel> ()
                .ToList();

            return profiles;
        }

        public async Task<ProfileModel> GetProfileByEmail (string email) {
            var profile = await _dbContext.Profiles
                .Include (x => x.ProfilePicture)
                .Include (x => x.Media)
                .Include (x => x.Events)
                .Include (x => x.GearModels)
                .Include (x => x.ProfilePicture)
                .FirstOrDefaultAsync (x => x.EmailAddress.Equals (email));

            if (profile == null) {
                return new ProfileModel ();
            }

            return profile;
        }

        public async Task<ProfileModel> GetProfileById (int id) {
            var profile = await _dbContext.Profiles
                .Include (x => x.ProfilePicture)
                .Include (x => x.Media)
                .Include (x => x.Events)
                .Include (x => x.GearModels)
                .Include (x => x.ProfilePicture)
                .FirstOrDefaultAsync (x => x.Id.Equals (id));

            if (profile == null) {
                return new ProfileModel ();
            }

            return profile;
        }
    }
}