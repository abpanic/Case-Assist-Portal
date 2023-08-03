using Microsoft.AspNetCore.Mvc;

namespace EmailTemplateApp.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
