using System.Collections.Generic;
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

        public Task<List<ProfileModel>> GetAllProfiles () {
            var profiles = _dbContext.Set<ProfileModel> ()
                .ToListAsync ();

            return profiles;
        }

        public Task<ProfileModel> GetProfileByEmail (string email) {
            var profile  = _dbContext.Profiles
            .SingleOrDefaultAsync(x => x.EmailAddress.Equals(email));

            return profile;
        }

        public Task<ProfileModel> GetProfileById (int id) {
            var profile =  _dbContext.Profiles
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

            return profile;
        }
    }
}