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
        private readonly SendCodeService _sendCodeService;

        public LogInApiController(LogInService logInService,SendCodeService sendCodeService)
        {
            _logInService = logInService;
            _sendCodeService = sendCodeService;
        }


        [HttpGet("CheckLogin")]
        public IActionResult LogInCheck(string UserName, string Password)
        {

            var result = _logInService.CheckLogIn(UserName, Password);

            if(result.MsgType == "success" && result.Msg == "User found but need to verify email address.")
            {
                HttpContext.Session.SetString("Username", result.Username);
                HttpContext.Session.SetInt32("UserId", result.UserId);
                HttpContext.Session.SetString("UserType", result.UserType);
                HttpContext.Session.SetString("IsLoggedIn", "false");               

            }

            if (result.MsgType == "success" && result.Msg == "Login Successful.")
            {
                HttpContext.Session.SetString("Username", result.Username);
                HttpContext.Session.SetInt32("UserId", result.UserId);
                HttpContext.Session.SetString("UserType", result.UserType);
                HttpContext.Session.SetString("IsLoggedIn", "true");
            }


            return Ok(result);

        }

        [HttpPost("CheckUser")]
        public async Task<IActionResult> CheckUser(VerifyEmail model)
        {

            var result = _logInService.CheckUser(model.Email);


            if(result.MsgType == "success")
            {

                SendCode sendCodeModel = new SendCode();

                sendCodeModel.Email = model.Email;
                sendCodeModel.Type = "Forget Password";

                var sendResetCodeRespose = await _sendCodeService.SendCode(sendCodeModel);

                return Ok(sendResetCodeRespose);
                 
            }
            
            else
            {
                return Ok(result);
            }



        }

        [HttpPost("VerifyResetCode")]
        public IActionResult VerifyResetCode(VerifyEmail model)
        {

            var result = _logInService.VerifyResetCode(model.Email, model.Code);

            return Ok(result);
           

        }
        
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword(PasswordReset model)
        {

            var result = _logInService.ResetPassword(model.Email, model.Password);

            return Ok(result);
           

        }





    }
}
