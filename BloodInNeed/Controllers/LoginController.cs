using Microsoft.AspNetCore.Mvc;
using BloodInNeed.UI.Models;
using BloodInNeed.Controllers;
using BloodInNeed.UI.Services;
using BloodInNeed.UI.Controllers.ApiControllers;

namespace BloodInNeed.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        private readonly SidebarMenuService _sideBarMenuService;

        private readonly SignupService _SignupService;

        public LoginController(ILogger<LoginController> logger, SidebarMenuService sidebarMenuService, SignupService SignupService)
   : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
            _SignupService = SignupService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (IsSessionLogIn())
            {

                await PopulateSidebarData();

                ViewBag.Username = CurrentUsername;

                return RedirectToAction("Index", "Home");

            }

            else
            {
                return View();
            }
        }

        [HttpGet]       
        public async Task<IActionResult> VerifyEmail(string Email)
        {
            if (IsSessionLogIn())
            {

                await PopulateSidebarData();

                ViewBag.Username = CurrentUsername;

                return RedirectToAction("Index", "Home");

            }

            else
            {

                var response = _SignupService.VerifyEmail(Email,0);

                if (response.MsgType == "success" && response.Msg == "This Email is already verified. Go to login page and try logging in.")
                {
                  return RedirectToAction("Index", "Login");
                }

                else
                {
                    ViewBag.VerificationEmail = Email;
                    return View();
                }

                  
            }

        }



        public IActionResult Verify(LoginModel login) 
        { 

            return View(); 
        }




        public IActionResult ForgetPassword()
        {

            return View();
        }









    }
}
