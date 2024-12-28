using BloodInNeed.Controllers;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers
{
    public class ProfileController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        private readonly SidebarMenuService _sideBarMenuService;


        public ProfileController(ILogger<HomeController> logger, SidebarMenuService sidebarMenuService)
   : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
        }
        public IActionResult Edit()
        {
            //if (IsSessionLogIn())
            //{

            //    PopulateSidebarData();
            //    ViewBag.Username = CurrentUsername;
            //    return View();

            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            return View();
        }
    }
}
