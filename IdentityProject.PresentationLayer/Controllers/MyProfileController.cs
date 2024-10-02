using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.PresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
