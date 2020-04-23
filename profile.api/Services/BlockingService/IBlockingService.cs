using System.Collections.Generic;
using System.Threading.Tasks;
using profile.data.DTO;

namespace profile.api.Services.BlockingService {
    public interface IBlockingService {
        Task<bool> Block(BlockedDTO blockingDTO);
        Task<bool> UnBlock(BlockedDTO blockingDTO);
        Task<bool> CheckBlocked(BlockedDTO blockingDTO);
        Task<List<BlockedDTO>> ListBlocked(int m_Id);
    }
}