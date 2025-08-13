using BloodInNeed.Controllers;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BloodInNeed.UI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly SidebarMenuService _sideBarMenuService;

        public string CurrentUsername => 
            HttpContext.Session.GetString("Username") ?? string.Empty;
        public int? CurrentUserId => HttpContext.Session.GetInt32("UserId") ?? 0;

        public string UserType => HttpContext.Session.GetString("UserType") ?? string.Empty;


        public BaseController(SidebarMenuService sidebarMenuService)
        {
            //Logger = logger;
            _sideBarMenuService = sidebarMenuService;
        }



        public async Task PopulateSidebarData()
        {
            var BloodGroupData = await _sideBarMenuService.GetBloodGroupsAll();

            UserInfo userInfo = new UserInfo();

            var currentUserId = HttpContext.Session.GetInt32("UserId")?? 0;
           

            userInfo = _sideBarMenuService.GetUserInfo(currentUserId);

            if(userInfo == null)
            {
                HttpContext.Session.SetString("Username", "");
                HttpContext.Session.SetInt32("UserId", 0);
                HttpContext.Session.SetString("UserType", "");

            }
            else
            {
                HttpContext.Session.SetString("Username", userInfo.UserName);
                HttpContext.Session.SetInt32("UserId", userInfo.UserId);
                HttpContext.Session.SetString("UserType", userInfo.DonorSeeker);
            }





            ViewBag.BloodGroups = BloodGroupData;
            ViewBag.BloodCount = BloodGroupData.Count();

            ViewBag.CurrentUsername = HttpContext.Session.GetString("Username");
            ViewBag.CurrentUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.CurrentUserType = HttpContext.Session.GetString("UserType");
        }




        public HighlightDataCounts HighlightsData()
        {
            var HighlightsData = _sideBarMenuService.HighlightData();
            
            return HighlightsData;
        }

        public SMTPSettings getSmtpSettings()
        {
            var SMTPSettingsData = _sideBarMenuService.getSmtpSettings();

            return SMTPSettingsData;
        }


        public IEnumerable<StatByCountry> GetStatByCountry(int CountryId)
        {
            var GetStatByCountry = _sideBarMenuService.GetStatByCountry(CountryId);

            return GetStatByCountry;
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

        public async Task<IActionResult> DonateDetail(int BGId)
        {
            await PopulateSidebarData();

            ViewBag.Username = CurrentUsername;

            var data = _sideBarMenuService.DonateDetail(BGId);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

    }
}
