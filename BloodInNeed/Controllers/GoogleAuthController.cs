using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Dapper;
using System.Data;
using System.Security.Claims;
using System.Data.SqlClient;
using BloodInNeed.UI.Services;

namespace BloodInNeed.UI.Controllers
{
    public class GoogleAuthController : Controller
    {
        private readonly IConfiguration _config;

        private readonly LogInService _logInService;

        public GoogleAuthController(IConfiguration config, LogInService logInService)
        {
            _config = config;
            _logInService = logInService;
        }

        [Route("SignInWithGoogle")]
        public IActionResult SignInWithGoogle()
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleCallback"),
            };

            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleCallback()
        {
            var authResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!authResult.Succeeded)
                return RedirectToAction("Index", "Login");

            var claims = authResult.Principal.Claims;

            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var fullName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            // Split name into first and last name
            string firstName = fullName?.Split(' ').FirstOrDefault() ?? "Google";
            string lastName = fullName?.Split(' ').Skip(1).FirstOrDefault() ?? "User";

            string username = email?.Split('@')[0];
            string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

            int userId;

            var response = _logInService.CheckGoogleLogIn(email, firstName, lastName, username, ip);

            userId = response.UserId;



            // Set your session keys (matching your app’s design)
            HttpContext.Session.SetString("UserId", userId.ToString());
            HttpContext.Session.SetString("Username", username);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("IsLoggedIn", "true");

            return RedirectToAction("Index", "Home");
        }


    }
}
