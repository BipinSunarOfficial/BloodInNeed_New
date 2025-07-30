using BloodInNeed.Models;
using BloodInNeed.UI.Controllers;
using BloodInNeed.UI.Models.ViewModels;
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
            var homepageViewModel = new HomePageViewModel();

            await PopulateSidebarData();

            var HighlightsDatas = HighlightsData();

            var getStatByCountry = GetStatByCountry(0);

            homepageViewModel.statByCountries = getStatByCountry;

            ViewBag.RegisteredDonors = HighlightsDatas.RegisteredDonors;
            ViewBag.BloodRequestsFulfilled = HighlightsDatas.BloodRequestsFulfilled;
            ViewBag.ActiveDonors = HighlightsDatas.ActiveDonors;

            if (IsSessionLogIn())
            {

                ViewBag.Username = CurrentUsername;

                return View(homepageViewModel);

            }

            else
            {
                //await PopulateSidebarData();
                //return RedirectToAction("Index", "Login");
                return View(homepageViewModel);
            }



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
