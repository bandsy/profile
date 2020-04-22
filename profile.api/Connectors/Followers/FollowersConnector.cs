using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using profile.api.EntityFramework;
using profile.data.FollowersModels;

namespace profile.api.Connectors.Followers {
    public class FollowersConnector : IFollowersConnector {
        private ProfileApiDbContext _dbContext;

        public FollowersConnector(ProfileApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Task<List<FollowersModel>> GetFollowers(int m_Id) {
            var followers = _dbContext.Followers
                .Where(x => x.m_Id.Equals(m_Id))
                .ToListAsync();

            return followers;
        }
        public async Task<int> AddFollower(FollowersModel followersModel) {
            var result = 0;

            if (followersModel != null) {
                _dbContext.Followers.Add(followersModel);
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<int> RemoveFollower(int m_Id, int f_Id) {
            var result = 0;
            var followerModel = await _dbContext.Followers
                .Where(x => x.m_Id.Equals(m_Id) && x.f_Id.Equals(f_Id))
                .FirstOrDefaultAsync();

            if (followerModel != null) {
                _dbContext.Remove(followerModel);
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}