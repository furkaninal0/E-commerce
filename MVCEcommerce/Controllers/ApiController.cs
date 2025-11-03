using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MVCEcommerce.Controllers;

public class ApiController (
    DbcontextEcommerce dbContext
    ) : Controller
{
    public async Task<IActionResult> GetCities(int id)
    {
        var model = await dbContext
            .Cities
            .Where(c => c.ProvinceId == id)
            .OrderBy(p=>p.Name)
            .Select(p=> new {p.Id, p.Name })
            .ToListAsync();
        return Json(model);
    }

}
