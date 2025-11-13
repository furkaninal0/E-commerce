using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;
using NETCore.MailKit.Core;
using NuGet.Common;

namespace MVCEcommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrators , OrderAdministrators")]
public class OrderController(DbcontextEcommerce dbContext, IEmailService emailService) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Yeni Siparişler";
        var model = await dbContext
            .Orders
            .Include(p => p.User)
            .Include(p => p.Items)
            .ThenInclude(p => p.Product)
            .OrderBy(p => p.Date)
            .Where(p => p.Status == MVCECommerceData.OrderStatus.New)
            .ToListAsync();
        return View(model);
    }
    public async Task<IActionResult> InProgess()
    {
        ViewData["Title"] = "Aktif Siparişler";

        var model = await dbContext
            .Orders
            .Include(p => p.User)
            .Include(p => p.Items)
            .ThenInclude(p => p.Product)
            .OrderBy(p => p.Date)
            .Where(p => p.Status == MVCECommerceData.OrderStatus.InProgress)
            .ToListAsync();
        return View("Index" , model);
    }
    public async Task<IActionResult> Shipped()
    {
        ViewData["Title"] = "Tamamlanan Siparişler";

        var model = await dbContext
            .Orders
            .Include(p => p.User)
            .Include(p => p.Items)
            .ThenInclude(p => p.Product)
            .OrderBy(p => p.Date)
            .Where(p => p.Status == OrderStatus.Shipped)
            .ToListAsync();
        return View("Index", model);
    }
    public async Task<IActionResult> Cancalled()
    {
        ViewData["Title"] = "İptaş Olan Siparişler";

        var model = await dbContext
            .Orders
            .Include(p => p.User)
            .Include(p => p.Items)
            .ThenInclude(p => p.Product)
            .OrderBy(p => p.Date)
            .Where(p => p.Status == OrderStatus.Cancelled)
            .ToListAsync();
        return View("Index", model);
    }

    public async Task<IActionResult> Detail(Guid id)
    {

        var model = await dbContext.Orders.Include(p => p.User)
            .Include(p => p.Items)
            .ThenInclude(p => p.Product)
            .SingleOrDefaultAsync(p => p.Id == id);
            return View(model);
    }
    public async Task<IActionResult> ToInProgress(Guid id)
    {

        var model = await dbContext
            .Orders
            .Include(p => p.User)
            .SingleOrDefaultAsync(p => p.Id == id);
       
        model.Status = MVCECommerceData.OrderStatus.InProgress;
        dbContext.Update(model);
        await dbContext.SaveChangesAsync();

        var body = $@"<h4> Merhabalar Sn. {model.User!.GivenName} </h4><p>Siparişiniz Hazırlanıyor</p>";

        await emailService.SendAsync(
            model.User.Email,
            "Siparişiniz Hakkında",
            body,
            true
            );

        return RedirectToAction(nameof(Index) );
    }
    public async Task<IActionResult> ToShipped(Guid id)
    {

        var model = await dbContext
            .Orders
            .Include(p => p.User)
            .SingleOrDefaultAsync(p => p.Id == id);

        model.Status = MVCECommerceData.OrderStatus.Shipped;
        dbContext.Update(model);
        await dbContext.SaveChangesAsync();

        var body = $@"<h4> Merhabalar Sn. {model.User!.GivenName} </h4><p>Siparişiniz yola çıkmıştır</p>";

        await emailService.SendAsync(
            model.User.Email,
            "Siparişiniz Hakkında",
            body,
            true
            );

        return RedirectToAction(nameof(Index));
    }



}
