using BloodInNeed.Controllers;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace BloodInNeed.UI.Controllers
{
    [RouteArea("BloodSearch", AreaPrefix = "BloodSearch")]
    public class BloodSearchController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        private readonly SidebarMenuService _sideBarMenuService;
        private readonly ProfileService _profileService;

        private BloodRequestService _bloodRequestService;


        public BloodSearchController(ILogger<HomeController> logger, SidebarMenuService sidebarMenuService, ProfileService profileService, BloodRequestService bloodRequestService)
   : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
            _profileService = profileService;
            _bloodRequestService = bloodRequestService;
        }

        [Route("Search")]
        public IActionResult Search()
        {

            PopulateSidebarData();

            ViewBag.Username = CurrentUsername;
            return View();
            
        }

        [Route("BloodRequest")]

        public IActionResult BloodRequest()
        {

            if(IsSessionLogIn())
            {

            UserInfo userInfo = new UserInfo();
            PopulateSidebarData();

            userInfo = _profileService.GetUserInfo(ViewBag.CurrentUserId);

                ViewBag.CityList = _profileService.CitybyUserId(ViewBag.CurrentUserId);

            return View(userInfo);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [Route("MyRequests")]

        public IActionResult MyRequests()
        {

            if (IsSessionLogIn())
            {
                PopulateSidebarData();

                var requestData = _bloodRequestService.MyRequests(ViewBag.CurrentUserId);
                return View(requestData);

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        //as a Donor
        [Route("ViewRequests")]

        public IActionResult ViewRequests()
        {

            if (IsSessionLogIn())
            {
                PopulateSidebarData();

                var requestData = _bloodRequestService.ViewRequests(ViewBag.CurrentUserId);
                return View(requestData);

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        //as a Donor
        [Route("MyDonations")]

        public IActionResult MyDonations()
        {

            if (IsSessionLogIn())
            {
                PopulateSidebarData();

                var requestData = _bloodRequestService.MyDonations(ViewBag.CurrentUserId);
                return View(requestData);

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



    }
}
