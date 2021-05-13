using Cleverbit.CodingTask.Application.abstractions;
using Cleverbit.CodingTask.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayGameController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IPlay _play;

        public PlayGameController(ILogger<AuthController> logger, IPlay play)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _play = play;
        }


        [HttpPost("{matchId:Guid}")]
        public async Task PlayNow([FromRoute] Guid matchId)
        {
            var id =  User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value.TryParseInt();
            await _play.PlayNow(id.Value, matchId);
        }
    }
}
