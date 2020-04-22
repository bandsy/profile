using System.Threading.Tasks;
using profile.api.EntityFramework;
using profile.data.FollowersModels;

namespace profile.api.Connectors.Followers {
    public class FollowersConnector : IFollowersConnector {
        private ProfileApiDbContext _dbContext;

        public FollowersConnector(ProfileApiDbContext dbContext) => _dbContext = dbContext;
        public async Task<int> AddFollower(FollowersModel followersModel) {
            var result = 0;

            if (followersModel != null) {
                _dbContext.Followers.Add(followersModel);
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}