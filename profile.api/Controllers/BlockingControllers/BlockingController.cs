using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.api.Services.BlockingService;
using profile.data.DTO;

namespace profile.api.Controllers.BlockingControllers {
    [ApiController]
    [Route("/api/v1/[controller]")]

    public class BlockingController : ControllerBase {

        public readonly IBlockingService _blockingService;
        public BlockingController(IBlockingService blockingService) {
            _blockingService = blockingService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> Block([FromBody] BlockedDTO blockedDTO) {
            var result = await _blockingService.Block(blockedDTO);

            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<bool> CheckBlocked([FromBody] BlockedDTO blockedDTO) {
            var result = await _blockingService.CheckBlocked(blockedDTO);

            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<BlockedDTO>> ListBlocked([FromQuery] int id) {
            var result = await _blockingService.ListBlocked(id);

            return result;
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<bool> UnBlock([FromBody] BlockedDTO blockedDTO) {
            var result = await _blockingService.UnBlock(blockedDTO);

            return result;
        }

    }
}