using Microsoft.AspNetCore.Mvc;

namespace MyNexus.ApplicationRegistry.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => RedirectPermanent("/swagger/index.html");
    }
}