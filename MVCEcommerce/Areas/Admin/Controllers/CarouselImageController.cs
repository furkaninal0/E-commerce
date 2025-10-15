﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Areas.Admin.Models;
using MVCECommerceData;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MVCEcommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrators , ProductAdministrators")]
public class CarouselImageController (
    DbcontextEcommerce dbContext
    ) : Controller  
{
    public async Task<IActionResult> Index()
    {
        var items = await dbContext.CarouselImages.Select(p=> new CarouselImageDto
        {  Id= p.Id,
           Url= p.Url,
           CreatedAt= p.CreatedAt,
           IsEnabled = p.IsEnabled,
           CatalogId = p.CatalogId
        }).ToListAsync();
        return View(items);
    }

    
    public IActionResult Create()
    {
        return View(new CarouselImageDto { IsEnabled = true });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarouselImageDto model)
    {
        var item = new CarouselImage();
       
        item.Url = model.Url;
        item.CreatedAt = DateTime.UtcNow;
        item.IsEnabled = model.IsEnabled;
        item.CatalogId = model.CatalogId;

        if (model.ImageFile is not null)
        {
            using var image = await Image.LoadAsync(model.ImageFile.OpenReadStream());
            image.Mutate(async p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size = new Size(1280, 400),
                    Mode = ResizeMode.Crop,

                });
                using var ms = new MemoryStream();
                await image.SaveAsWebpAsync(ms);
                item.Image = ms.ToArray();

            });

        }
        //model.Logo = model.LogoFile.OpenReadStream()

        dbContext.Add(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbContext.CarouselImages.FirstOrDefaultAsync(p => p.Id == id);
        return View(new CarouselImageDto {
            Id = item.Id,
            Url = item.Url,
            CatalogId = item.CatalogId,
            IsEnabled = item.IsEnabled,
        } );
    }
    [HttpPost]
    public async Task<IActionResult> Edit(CarouselImageDto model)
    {
        var item = await dbContext.CarouselImages.SingleOrDefaultAsync(p => p.Id == model.Id);

        item.Url = model.Url;
        item.IsEnabled = model.IsEnabled;
        item.CatalogId = model.CatalogId;

        item.IsEnabled = model.IsEnabled;
        if (model.ImageFile is not null)
        {
            using var image = await Image.LoadAsync(model.ImageFile.OpenReadStream());
            image.Mutate(async p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size = new Size(1280, 400),
                    Mode = ResizeMode.Crop,

                });
                using var ms = new MemoryStream();
                await image.SaveAsWebpAsync(ms);
                item.Image = ms.ToArray();

            });

        }

        dbContext.Update(item);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbContext.CarouselImages.SingleOrDefaultAsync(p => p.Id == id);
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
