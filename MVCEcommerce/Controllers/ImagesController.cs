using Microsoft.AspNetCore.Mvc;
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

        // Ürün bulunamadıysa
        if (item == null)
        {
            return NotFound("Ürün bulunamadı.");
        }

        // Resim yoksa varsayılan resim dön
        if (item.Image == null)
        {
            var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/noimage.png");
            var defaultImage = await System.IO.File.ReadAllBytesAsync(defaultImagePath);
            return File(defaultImage, "image/webp");
        }

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

