using BloodInNeed.Controllers;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BloodInNeed.UI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly SidebarMenuService _sideBarMenuService;

        public BaseController(SidebarMenuService sidebarMenuService)
        {
            //Logger = logger;
            _sideBarMenuService = sidebarMenuService;
        }

        public async Task PopulateSidebarData()
        {
            var BloodGroupData =  _sideBarMenuService.GetBloodGroupsAll();

            ViewBag.BloodGroups = BloodGroupData;
        }

    }
}
