using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MVCEcommerce.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize(Roles = "Administrators , ProductAdministrators")]
public class BrandsController( 
    DbcontextEcommerce dbcontext
    ) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbcontext.Brands.OrderBy(p => p.Name).ToListAsync();

        return View(items);
    }
    public IActionResult Create()
    {
        return View(new Brand { });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Brand model)
    {
        model.CreatedAt = DateTime.UtcNow;
        if(model.LogoFile is not null)
        {
            using var image = await Image.LoadAsync(model.LogoFile.OpenReadStream());
            image.Mutate(async p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size = new Size(180, 180),
                    Mode = ResizeMode.Max

                });
                using var ms = new MemoryStream();
                await image.SaveAsWebpAsync(ms);
                model.Logo = ms.ToArray();

            });

        }
        //model.Logo = model.LogoFile.OpenReadStream()
        
        dbcontext.Add(model);
        await dbcontext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbcontext.Brands.FirstOrDefaultAsync(p => p.Id == id);
        return View(item);
    }   
    [HttpPost]
    public async Task<IActionResult> Edit(Brand model)
    {
        var item = await dbcontext.Brands.SingleOrDefaultAsync(p => p.Id == model.Id);

        item.Name = model.Name;
        item.IsEnabled = model.IsEnabled;
        if (model.LogoFile is not null)
        {
            using var image = await Image.LoadAsync(model.LogoFile.OpenReadStream());
            image.Mutate(async p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size = new Size(210, 210),
                    Mode = ResizeMode.Max

                });
                using var ms = new MemoryStream();
                await image.SaveAsWebpAsync(ms);
                item.Logo = ms.ToArray();

            });

        }

        dbcontext.Update(item);
        await dbcontext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbcontext.Brands.SingleOrDefaultAsync(p => p.Id == id);
        dbcontext.Remove(item);
        await dbcontext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


}
