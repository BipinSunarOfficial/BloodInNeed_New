using BloodInNeed.Models;
using BloodInNeed.UI.Controllers;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BloodInNeed.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SidebarMenuService _sideBarMenuService;


        //public HomeController(ILogger<HomeController> logger, SidebarMenuService sidebarMenuService)
        //{
        //    _logger = logger;
        //    _sideBarMenuService = sidebarMenuService;
        //}

        public HomeController(ILogger<HomeController> logger, SidebarMenuService sidebarMenuService)
    : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
        }

        public async Task<IActionResult> Index()
        {
            await PopulateSidebarData();
            //var BloodGroupData = _sideBarMenuService.GetBloodGroupsAll();

            //Console.WriteLine(BloodGroupData);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
