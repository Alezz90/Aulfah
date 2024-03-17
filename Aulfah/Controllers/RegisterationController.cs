using Microsoft.AspNetCore.Mvc;

namespace Aulfah.PL.Controllers
{
    public class RegisterationController : Controller
    {
        public IActionResult Signin()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
    }
}
