using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;

namespace MVCEcommerce.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize(Roles = "Administrators , ProductAdministrators")]
public class CatalogsController( 
    DbcontextEcommerce dbcontext
    ) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbcontext.Catalogs.OrderBy(p => p.NameTr).ToListAsync();

        return View(items);
    }
    public IActionResult Create()
    {
        return View(new Catalog { });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Catalog model)
    {
        model.CreatedAt = DateTime.UtcNow;

        dbcontext.Add(model);
        await dbcontext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbcontext.Catalogs.FirstOrDefaultAsync(p => p.Id == id);
        return View(item);
    }   
    [HttpPost]
    public async Task<IActionResult> Edit(Catalog model)
    {
        var item = await dbcontext.Catalogs.SingleOrDefaultAsync(p => p.Id == model.Id);

        item.NameTr = model.NameTr;
        item.NameEn = model.NameEn;
        item.IsEnabled = model.IsEnabled;

        dbcontext.Update(item);
        await dbcontext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbcontext.Catalogs.SingleOrDefaultAsync(p => p.Id == id);
        dbcontext.Remove(item);
        await dbcontext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


}
