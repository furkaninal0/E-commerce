﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using MVCECommerceData;

namespace MVCEcommerce.Controllers;

public class ImagesController(DbcontextEcommerce dbContext) : Controller
{
    
        [OutputCache(Duration = 86400)]
        public async Task<IActionResult> Brand(Guid id)
        {
            var item = await dbContext.Brands.FindAsync(id);
            return File(item.Logo, "image/webp");
        }

        [OutputCache(Duration = 86400)]
        public async Task<IActionResult> Product(Guid id)
        {
            var item = await dbContext.Products.FindAsync(id);
            return File(item.Image, "image/webp");
        }

        [OutputCache(Duration = 86400)]
        public async Task<IActionResult> ProductImage(Guid id)
        {
            var item = await dbContext.ProductImages.FindAsync(id);
            return File(item.Image, "image/webp");
        }

        [OutputCache(Duration = 86400)]
        public async Task<IActionResult> CarouselImage(Guid id)
        {
            var item = await dbContext.CarouselImages.FindAsync(id);
            return File(item.Image, "image/webp");
        }
}

