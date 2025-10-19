﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MVCEcommerce.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize(Roles = "Administrators,ProductAdministrators")]
public class ProductsController(
DbcontextEcommerce dbContext
) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbContext.Products.OrderBy(p => p.NameTr).ToListAsync();
        return View(items);
    }

    public IActionResult Create()
    {
        return View(new Product { });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model)
    {
        model.CreatedAt = DateTime.UtcNow;

        var form = Request.Form;

        var specs = await dbContext.Specifications.ToListAsync();

        specs
            .Where(p => !string.IsNullOrEmpty(form[p.Id.ToString()]))
            .ToList()
            .ForEach(p =>
            {
                model.Specs.Add(new ProductSpecification
                {
                    SpecificationId = p.Id,
                    Value = form[p.Id.ToString()]
                });
            });

        // --- ANA DÜZELTME BURADA ---
        var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp", "image/gif", "image/bmp" };

        if (model.ImageFile is not null && model.ImageFile.Length > 0)
        {
            if (!allowedTypes.Contains(model.ImageFile.ContentType))
            {
                ModelState.AddModelError("ImageFile", "Desteklenmeyen resim formatı (yalnızca JPG, PNG, WEBP, GIF, BMP).");
                return View(model);
            }

            try
            {
                using var image = await Image.LoadAsync(model.ImageFile.OpenReadStream());
                image.Mutate(p =>
                {
                    p.Resize(new ResizeOptions
                    {
                        Size = new Size(800, 600),
                        Mode = ResizeMode.BoxPad
                    });
                });
                using var ms = new MemoryStream();
                await image.SaveAsWebpAsync(ms);
                model.Image = ms.ToArray();
            }
            catch (UnknownImageFormatException)
            {
                ModelState.AddModelError("ImageFile", "Geçersiz veya bozuk resim formatı yüklendi.");
                return View(model);
            }
        }

        if (model.ImageFiles is not null)
        {
            foreach (var file in model.ImageFiles)
            {
                if (file.Length == 0 || !allowedTypes.Contains(file.ContentType))
                    continue;

                try
                {
                    using var image = await Image.LoadAsync(file.OpenReadStream());
                    image.Mutate(p =>
                    {
                        p.Resize(new ResizeOptions
                        {
                            Size = new Size(800, 600),
                            Mode = ResizeMode.BoxPad
                        });
                    });
                    using var ms = new MemoryStream();
                    await image.SaveAsWebpAsync(ms);
                    model.ProductImages.Add(new ProductImage
                    {
                        IsEnabled = true,
                        CreatedAt = DateTime.UtcNow,
                        Image = ms.ToArray()
                    });
                }
                catch (UnknownImageFormatException)
                {
                    // Bu dosya desteklenmeyen bir formatta, sadece atla
                    continue;
                }
            }
        }

        if (model.SelectedCatalogs is not null)
            model.SelectedCatalogs.ToList().ForEach(p => model.Catalogs.Add(dbContext.Catalogs.Find(p)!));

        dbContext.Add(model);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }



    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbContext
            .Products
            .Include(p => p.Catalogs)
            .Include(p => p.Specs)
            .SingleOrDefaultAsync(p => p.Id == id);
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product model)
    {
        var item = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == model.Id);

        item.NameTr = model.NameTr;
        item.NameEn = model.NameEn;
        item.DescriptionEn = model.DescriptionEn;
        item.DescriptionTr = model.DescriptionTr;
        item.Price = model.Price;
        item.BrandId = model.BrandId;
        item.CategoryId = model.CategoryId;
        item.Image = model.Image;

        item.IsEnabled = model.IsEnabled;


        var form = Request.Form;

        await dbContext.ProductSpecifications.Where(p => p.ProductId == model.Id).ExecuteDeleteAsync();

        var specs = await dbContext.Specifications.ToListAsync();

        specs
            .Where(p => !string.IsNullOrEmpty(form[p.Id.ToString()]))
            .ToList()
            .ForEach(p =>
            {
                model.Specs.Add(new ProductSpecification
                {
                    SpecificationId = p.Id,
                    Value = form[p.Id.ToString()]
                });
            });


        if (model.ImageFile is not null)
        {
            using var image = await Image.LoadAsync(model.ImageFile.OpenReadStream());
            image.Mutate(p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size = new Size(180, 180),
                    Mode = ResizeMode.Max
                });
            });
            using var ms = new MemoryStream();
            await image.SaveAsWebpAsync(ms);
            item.Image = ms.ToArray();
        }

        dbContext.Update(item);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}