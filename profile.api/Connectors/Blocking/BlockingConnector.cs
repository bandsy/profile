using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using profile.api.EntityFramework;
using profile.data.BlockingModels;

namespace profile.api.Connectors.Blocking {
    public class BlockingConnector : IBlockingConnector {

        public readonly ProfileApiDbContext _dbContext;
        public BlockingConnector(ProfileApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<int> Block(BlockedModel blockedModel) {
            var result = 0;

            await _dbContext.Blocked.AddAsync(blockedModel);
            result = await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<BlockedModel> CheckBlocked(int m_Id, int b_Id) {
            var result = await _dbContext.Blocked
                .Where(x => x.m_Id.Equals(m_Id) && x.b_Id.Equals(b_Id))
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<BlockedModel>> ListBlocked(int m_Id) {
            var records = await _dbContext.Blocked
                .Where(x => x.m_Id.Equals(m_Id))
                .ToListAsync();

            return records;
        }

        public async Task<int> UnBlock(int m_Id, int b_Id) {
            var result = 0;

            var record = await _dbContext.Blocked
                .Where(x => x.m_Id.Equals(m_Id) && x.b_Id.Equals(b_Id))
                .FirstOrDefaultAsync();

            if (record != null) {
                _dbContext.Remove(record);
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}