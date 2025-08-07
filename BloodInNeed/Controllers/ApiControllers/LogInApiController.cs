using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;

//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Serilog;

namespace BloodInNeed.UI.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/login")]
    public class LogInApiController : ControllerBase
    {

        private readonly LogInService _logInService;

        public LogInApiController(LogInService logInService)
        {
            _logInService = logInService;
        }


        [HttpGet("CheckLogin")]
        public IActionResult LogInCheck(string UserName, string Password)
        {

            var result = _logInService.CheckLogIn(UserName, Password);

            if(result.MsgType == "success" && result.Msg == "User found but need to verify email address.")
            {
                HttpContext.Session.SetString("Username", result.Username);
                HttpContext.Session.SetString("IsLoggedIn", "false");               

            }

            if (result.MsgType == "success" && result.Msg == "Login Successful.")
            {
                HttpContext.Session.SetString("Username", result.Username);
                HttpContext.Session.SetString("IsLoggedIn", "true");
            }


            return Ok(result);

        }


    }
}
