using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Models;
using MVCECommerceData;
using NETCore.MailKit.Core;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCEcommerce.Controllers;

public class AccountController(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IEmailService emailService,
    DbcontextEcommerce dbContext

    ) : Controller

{
    public IActionResult Login()
    {
        return View(new LoginUserViewModel {IsPersistent = true});
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserViewModel model)
    {   
            var result = await signInManager.PasswordSignInAsync(
            model.UserName!,
            model.Password!,
            isPersistent: model.IsPersistent,
            lockoutOnFailure: true);

        if (result.Succeeded)
        {
            var user = await userManager.FindByNameAsync(model.UserName!);
            if (!user.IsEnabled)
                await signInManager.SignOutAsync();
            else
                return Redirect(model.ReturnUrl ?? "/");
        }
        ModelState.AddModelError("", "Geçersiz kullanıcı girişi");
        return View(model);

    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModel model)
    {
        var user = new User()
        {
            UserName = model.UserName,
            Email = model.UserName,
            GivenName = model.GivenName,
            Date = DateTime.Now,
            Gender = model.Gender,
        };
        var result = await userManager.CreateAsync(user, model.Password!);
        if (result.Succeeded)
        {
            //await userManager.AddClaimAsync(user, new Claim(ClaimTypes.GivenName, model.GivenName!));
            await userManager.AddToRoleAsync(user, "Members");
            //await signInManager.SignInAsync(user, isPersistent: false);
            //return RedirectToAction("Index", "Home");

            //TODO: MAİL GÖNDERİLECEK
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("EmailConfirmation", "Account", new { user.Id, token }, Request.Scheme);
            var body = $@"<h4> Merhabalar Sn. {user.GivenName} </h4><p>...</p><a href=""{link}"">link</a>";

            await emailService.SendAsync(
                user.Email,
                "MvcForum E-posta doğrulama mesajı",
                body,
                true

                );

            return View("RegisterSuccess");

        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return View(model);
    }
    public async Task<IActionResult> EmailConfirmation(Guid id, string token)
    {

        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null) return View("Error");

        var result = await userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        return View();

    }
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    public IActionResult ResetPassword()
    {
        return View();
    }



    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        var user = await userManager.FindByNameAsync(model.UserName!);
        if (user == null)
        {
            ModelState.AddModelError("", "Kullanıcı bulunamıyor!");
            return View(model);
        }
        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var link = Url.Action("SetPassword", "Account", new { user.Id, token }, Request.Scheme);
        var body = $@"<h4> Merhabalar Sn. {user.GivenName} </h4><p>...</p><a href=""{link}"">link</a>";

        await emailService.SendAsync(
            user.Email,
            "MvcForum parola yenileme mesajı",
            body,
            true
            );
        return View("ResetPasswordSuccess");
    }
    public IActionResult SetPassword(Guid id, string token)
    {
        return View(new SetPassWordViewModel { Id = id, Token = token });
    }

    [HttpPost]
    public async Task<IActionResult> SetPassword(SetPassWordViewModel model)

    {
        var user = await userManager.FindByIdAsync(model.Id!.ToString());
        var result = await userManager.ResetPasswordAsync(user!, model.Token!, model.Password!);
        return View("SetPasswordSuccessMasallah");

    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> AddToCart(Guid id)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var product = await dbContext.Products.SingleAsync(p=>p.Id==id);
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.UserId == userId && p.ProductId == id);
        if (item == null)
        {

            item = new ShoppingCartItem
            {
                ProductId = id,
                UserId = userId,
                Quantity = 1,
            };
        dbContext.ShoppingCartItems.Add(item);
        }

        else
        {
            item.Quantity++;
            dbContext.ShoppingCartItems.Update(item);
        }
        TempData["success"] = "Product addet to your cart successfully!";
        await dbContext.SaveChangesAsync();
        return RedirectToRoute("Product", new { id, name = product.NameEn.ToSafeUrlString() });
       
    }
    [Authorize]
    

    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await dbContext.ShoppingCartItems.Where(p=>p.Id == id && p.UserId == userId!).ExecuteDeleteAsync();
        return RedirectToAction(nameof(Checkout));
    }
    [Authorize]

    public IActionResult Checkout()
    {
        return View();
    }
    [Authorize]

    public IActionResult Payment()
    {
        return View();
    }
    [Authorize]

    public async Task<IActionResult> SetQuantity(Guid id, int Quantity)
    {
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.Id == id);
        item.Quantity=Quantity; 
        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Checkout));



    }
    [Authorize]

    public async Task<IActionResult> IncreaseQuantity(Guid id)
    {
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.Id == id);
        item.Quantity++;
        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Checkout));



    }
    [Authorize]

    public async Task<IActionResult> DescreaseQuantity(Guid id)
    {
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.Id == id);
        if (item.Quantity > 1)
        item.Quantity--;
        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Checkout));
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAddress([FromBody]AddressViewModel model)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var address = new Address
        {
            Name = model.Name,
            Text = model.Text,
            CityId = model.CityId,
            ZipCode = model.ZipCode,
            UserId = userId,
        };
        dbContext.Add(address);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
    [Authorize]
    public async Task<IActionResult> UserAddress()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var model = await dbContext
            .Addresses
            .Where(a => a.UserId == userId)
            .Select(p=> new { p.Id, p.Name, p.Text,  })
            .ToListAsync();


        return Json(model);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Pay([FromBody]PaymentViewModel model)
    {
        if (model == null)
            return BadRequest("Model null geldi.");

        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdString))
            return Unauthorized("User not authenticated");

        var userId = Guid.Parse(userIdString);
        //payment logic here
#if DEBUG
        Thread.Sleep(5000);
#endif

        // /payment logic 
        var order = new Order()
        {
            Date = DateTime.Now,
            ShippingAddressId = model.ShippingAddressId,
            UserId = userId,
            Items = dbContext
            .ShoppingCartItems
            .Include(p => p.Product)
            .Where(p => p.UserId == userId)
            .Select(p => new OrderItem {
                Price = p.Product.Price, 
                Quantity = p.Quantity,
                ProductId = p.ProductId,


            }).ToList(),

        };
        dbContext.Add(order);
        await dbContext.SaveChangesAsync();
        await dbContext.ShoppingCartItems.Where(p=>p.UserId==userId).ExecuteDeleteAsync();
        return Ok();
    }
    public async Task<IActionResult> Profile()
    {
        var user = await userManager.GetUserAsync(User);


        return View(user);
    }

}