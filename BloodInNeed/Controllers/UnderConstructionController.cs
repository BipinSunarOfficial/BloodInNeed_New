using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers
{
    public class UnderConstructionController : BaseController
    {

        private readonly ILogger<UnderConstructionController> _logger;
        private readonly SidebarMenuService _sideBarMenuService;

        public UnderConstructionController(ILogger<UnderConstructionController> logger, SidebarMenuService sidebarMenuService)
  : base(sidebarMenuService)
        {
            _logger = logger;
            _sideBarMenuService = sidebarMenuService;
        }
        public async Task<IActionResult> Index()
        {
            await PopulateSidebarData();

            ViewBag.Username = CurrentUsername;

            return View();
        }
    }
}
