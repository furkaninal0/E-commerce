using Microsoft.AspNetCore.Mvc;

namespace MVCEcommerce.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
