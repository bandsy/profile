using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using profile.api.Connectors.Blocking;
using profile.data.BlockingModels;
using profile.data.DTO;

namespace profile.api.Services.BlockingService {
    public class BlockingService : IBlockingService {
        public readonly IBlockingConnector _blockingConnector;
        private readonly IMapper _mapper;
        public BlockingService(IBlockingConnector blockingConnector, IMapper mapper) {
            _blockingConnector = blockingConnector;
            _mapper = mapper;
        }

        public async Task<bool> Block(BlockedDTO blockingDTO) {
            var blockedModel = _mapper.Map<BlockedModel>(blockingDTO);
            var result = await _blockingConnector.Block(blockedModel);

            return result > 0 ? true : false;
        }

        public async Task<bool> CheckBlocked(BlockedDTO blockingDTO) {
            var result = await _blockingConnector.CheckBlocked(blockingDTO.m_Id, blockingDTO.b_Id);

            return result != null ? true : false;
        }

        public async Task<List<BlockedDTO>> ListBlocked(int m_Id) {
            var blockedDTOs = new List<BlockedDTO>();
            var results = await _blockingConnector.ListBlocked(m_Id);

            foreach (var result in results) {
                blockedDTOs.Add(_mapper.Map<BlockedDTO>(result));
            }

            return blockedDTOs;
        }

        public async Task<bool> UnBlock(BlockedDTO blockingDTO) {
            var result = await _blockingConnector.UnBlock(blockingDTO.m_Id, blockingDTO.b_Id);

            return result > 0 ? true : false;
        }
    }
}