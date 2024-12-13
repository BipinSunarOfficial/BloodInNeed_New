using BloodInNeed.Controllers;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace BloodInNeed.UI.Controllers
{
    [RouteArea("BloodSearch", AreaPrefix = "BloodSearch")]
    public class BloodSearchController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        private readonly SidebarMenuService _sideBarMenuService;


        public BloodSearchController(ILogger<HomeController> logger, SidebarMenuService sidebarMenuService)
   : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
        }

        [Route("Search")]
        public IActionResult Search()
        {
            if (IsSessionLogIn())
            {

                PopulateSidebarData();
                ViewBag.Username = CurrentUsername;
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
