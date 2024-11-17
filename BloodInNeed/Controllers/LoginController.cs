using Microsoft.AspNetCore.Mvc;
using BloodInNeed.UI.Models;

namespace BloodInNeed.UI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Verify(LoginModel login) 
        { 

            return View(); 
        }
    }
}
