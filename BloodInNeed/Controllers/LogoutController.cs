using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Clear();

            ViewBag.Username = "";

            return RedirectToAction("Index", "Home");


        }
    }
}
