using BloodInNeed.Controllers;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BloodInNeed.UI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly SidebarMenuService _sideBarMenuService;

        public string CurrentUsername => HttpContext.Session.GetString("Username") ?? string.Empty;


        public BaseController(SidebarMenuService sidebarMenuService)
        {
            //Logger = logger;
            _sideBarMenuService = sidebarMenuService;
        }



        public async Task PopulateSidebarData()
        {
            var BloodGroupData =  _sideBarMenuService.GetBloodGroupsAll();

            ViewBag.BloodGroups = BloodGroupData;
            ViewBag.CurrentUsername = HttpContext.Session.GetString("IsLoggedIn");
        }

        public bool IsSessionLogIn()
        {
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
            if (isLoggedIn == "true" || isLoggedIn == "True")
            {
                ViewBag.Username = CurrentUsername;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
