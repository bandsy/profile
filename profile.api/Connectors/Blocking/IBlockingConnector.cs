using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.BlockingModels;

namespace profile.api.Connectors.Blocking {
    public interface IBlockingConnector {
        Task<int> Block(BlockedModel blockedModel);
        Task<BlockedModel> CheckBlocked(int m_Id, int b_Id);
        Task<List<BlockedModel>> ListBlocked(int m_Id);
        Task<int> UnBlock(int m_Id, int b_Id);
    }
}