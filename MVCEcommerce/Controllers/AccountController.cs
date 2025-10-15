using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models;
using MVCECommerceData;
using NETCore.MailKit.Core;
using System.Security.Claims;

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







}