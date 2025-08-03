using BloodInNeed.Controllers;
using BloodInNeed.UI.Models;
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
            var BloodGroupData = await _sideBarMenuService.GetBloodGroupsAll();

            ViewBag.BloodGroups = BloodGroupData;
            ViewBag.BloodCount = BloodGroupData.Count();
            ViewBag.CurrentUsername = HttpContext.Session.GetString("Username");
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
