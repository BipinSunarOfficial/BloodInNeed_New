using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers.ApiControllers
{
    [Route("api/signup")]
    [ApiController]
    public class SignupApiController : ControllerBase
    {
        private readonly SignupService _signupService;

        public SignupApiController(SignupService signupService)
        {
            _signupService = signupService;
        }

        [HttpPost("SignUpUser")]
        public IActionResult SignUpUser(UserRegistrarionModel model)
        {
            var result = _signupService.SignUpUser(model);

            return Ok(result);
        }
    }
}
