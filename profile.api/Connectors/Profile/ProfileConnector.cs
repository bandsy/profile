using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using profile.api.EntityFramework;
using profile.data.ProfileModels;

namespace profile.api.Connectors.Profile {
    public class ProfileConnector : IProfileConnector {

        private ProfileApiDbContext _dbContext;

        public ProfileConnector(ProfileApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Task<List<ProfileModel>> GetAllProfiles() {
            var profiles = _dbContext.Profiles
                .Include(x => x.ProfilePicture)
                .Include(x => x.Media)
                .Include(x => x.Events)
                .Include(x => x.Availability)
                .Include(x => x.Experience)
                .Include(x => x.GearModels)
                .ToListAsync();

            return profiles;
        }

        public async Task<ProfileModel> GetProfileByEmail(string email) {
            var profile = await _dbContext.Profiles
                .Include(x => x.ProfilePicture)
                .Include(x => x.Media)
                .Include(x => x.Events)
                .Include(x => x.Availability)
                .Include(x => x.Experience)
                .Include(x => x.GearModels)
                .FirstOrDefaultAsync(x => x.EmailAddress.Equals(email));

            if (profile == null) {
                return new ProfileModel();
            }

            return profile;
        }

        public async Task<ProfileModel> GetProfileById(int m_ID) {
            var profile = await _dbContext.Profiles
                .Include(x => x.ProfilePicture)
                .Include(x => x.Media)
                .Include(x => x.Events)
                .Include(x => x.Experience)
                .Include(x => x.Availability)
                .Include(x => x.GearModels)
                .FirstOrDefaultAsync(x => x.m_ID.Equals(m_ID));

            if (profile == null) {
                return new ProfileModel();
            }

            return profile;
        }

        public async Task<ProfileModel> GetProfileByUsername(string username) {
            var profile = await _dbContext.Profiles
                .Include(x => x.ProfilePicture)
                .Include(x => x.Media)
                .Include(x => x.Events)
                .Include(x => x.Experience)
                .Include(x => x.Availability)
                .Include(x => x.GearModels)
                .FirstOrDefaultAsync(x => x.Username.Equals(username));

            if (profile == null) {
                return new ProfileModel();
            }

            return profile;

        }

        public async Task<int> AddProfile(ProfileModel profile) {
            var result = 0;

            await _dbContext.Profiles.AddAsync(profile);
            result = await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateProfile(ProfileModel profileToUpdate) {
            var result = 0;
            _dbContext.Update(profileToUpdate);

            result = await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<int> DeleteProfile(int m_ID) {
            var result = 0;
            var profileModel = await GetProfileById(m_ID);

            if (profileModel != null) {
                _dbContext.Profiles.Remove(profileModel);

                result = await _dbContext.SaveChangesAsync();
            }

            return result;

        }

    }
}