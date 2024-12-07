using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
