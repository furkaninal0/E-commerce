using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;
using System.Threading.Tasks;

namespace MVCEcommerce.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize]
public class CategoriesController(
    DbcontextEcommerce dbcontext
    ) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbcontext.Categories.OrderBy(p => p.NameTr).ToListAsync();

        return View(items);
    }
    public IActionResult Create()
    {
        return View(new Category { });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category model)
    {
        model.CreatedAt = DateTime.UtcNow;

        dbcontext.Add(model);
        await dbcontext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbcontext.Categories.FirstOrDefaultAsync(p => p.Id == id);
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category model)
    {
        var item = await dbcontext.Categories.SingleOrDefaultAsync(p => p.Id == model.Id);

        item.NameTr = model.NameTr;
        item.NameEn = model.NameEn;
        item.IsEnabled = model.IsEnabled;

        dbcontext.Update(item);
        await dbcontext.SaveChangesAsync();
       
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbcontext.Categories.SingleOrDefaultAsync(p => p.Id == id);
        dbcontext.Remove(item);
        await dbcontext.SaveChangesAsync();  
        return RedirectToAction(nameof(Index));
    }



}
