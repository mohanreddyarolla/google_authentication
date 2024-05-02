using GoogleAuthApi.AuthServices;
using GoogleAuthApi.Contracts;
using GoogleAuthApi.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : Controller
    {
        private readonly IIdentityProvider _identityProvider;

        public IdentityController(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        [HttpPost("google-login")]
        public async Task<ActionResult<string>> GoogleLogin(GoogleSignIn data)
        {
            return Ok(await _identityProvider.ValidateGoogleToken(data.IdToken));
        }
    }
}
