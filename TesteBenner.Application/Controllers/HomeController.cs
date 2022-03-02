using Microsoft.AspNetCore.Mvc;

namespace TesteBenner.Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "ControleEstacionamento");
        }
    }
}
