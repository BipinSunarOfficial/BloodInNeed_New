using Microsoft.AspNetCore.Mvc;
using BloodInNeed.UI.Models;
using BloodInNeed.Controllers;
using BloodInNeed.UI.Services;

namespace BloodInNeed.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        private readonly SidebarMenuService _sideBarMenuService;

        public LoginController(ILogger<LoginController> logger, SidebarMenuService sidebarMenuService)
   : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
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

        public IActionResult Verify(LoginModel login) 
        { 

            return View(); 
        }
    }
}
