using BloodInNeed.Controllers;
using BloodInNeed.UI.Models.ViewModels;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers
{
    public class ProfileController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        private readonly SidebarMenuService _sideBarMenuService;

        private readonly ProfileService _profileService;


        public ProfileController(ILogger<HomeController> logger, SidebarMenuService sidebarMenuService, ProfileService profileService)
   : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
            _profileService = profileService;
        }
        public IActionResult Edit()
        {
            if (IsSessionLogIn())
            {

                PopulateSidebarData();
                ViewBag.Username = CurrentUsername;
                ViewBag.UserId = CurrentUserId;

                var viewModel = new EditProfileViewModel();



                viewModel.CountryList = _profileService.GetCountryList();


                viewModel.UserInfo = _profileService.GetUserInfo(ViewBag.UserId);

                viewModel.bloodGroups = _profileService.GetBloodGroups();

                viewModel.Cities = _profileService.CitybyCountryId(viewModel.UserInfo.Country);

                return View(viewModel);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}
