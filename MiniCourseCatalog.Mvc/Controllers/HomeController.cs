using Microsoft.AspNetCore.Mvc;

namespace MiniCourseCatalog.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
