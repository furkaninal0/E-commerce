using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MVCEcommerce.Controllers;

public class HomeController (
    DbcontextEcommerce dbContext
    ): Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Category(Guid id)
    {
        var model = await dbContext.Categories.Include(p=>p.Products).SingleOrDefaultAsync(p=>p.Id == id);
        return View(model);
    }


}
