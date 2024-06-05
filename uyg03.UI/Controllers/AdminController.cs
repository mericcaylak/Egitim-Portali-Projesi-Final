using Microsoft.AspNetCore.Mvc;

namespace SoruCevap.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
