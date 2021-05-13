using Cleverbit.CodingTask.Application.abstractions;
using Cleverbit.CodingTask.Application.Requests;
using Cleverbit.CodingTask.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuth _auth;

        public AuthController(ILogger<AuthController> logger, IAuth auth)
        {
            _auth = auth;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/auth
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
        [Authorize]
        public async Task<ActionResult<UserResponse>> Get()
        {

            var user = await _auth.GetUser(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value);

            if (user == null)
            {
                _logger.LogError($"User not found.");

                return NotFound();
            }

            user.Password = null;
            return Ok(user);
        }


        // POST: api/auth/signin
        [HttpPost("signin")]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] UserAuthRequest userAuth)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid properties.");
                return BadRequest();
            }

            if (!await _auth.ValidateUser(userAuth))
                return Forbid();

            return Ok();
        }

    }
}
