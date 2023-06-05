using AutoMapper;
using Cymax.WebApp.Models;
using Cymax.WebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cymax.WebApp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public AccountController(UserManager<User> userManager , 
                            IMapper mapper,
                            SignInManager<User> signInManager)
    {
        this._userManager = userManager;
        this._mapper = mapper;
        this._signInManager = signInManager;
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegistrationRequestModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return View(userModel);
        }
        var user = _mapper.Map<User>(userModel);
        var result = await _userManager.CreateAsync(user, userModel.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return View(userModel);
        }
        await _userManager.AddToRoleAsync(user, "Visitor");
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginRequestModel userModel , string returnUrl = null)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View(userModel);
        //}
        //var user = await _userManager.FindByEmailAsync(userModel.Email);
        //if (user != null &&
        //    await _userManager.CheckPasswordAsync(user, userModel.Password))
        //{
        //    var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
        //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
        //    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
        //    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
        //        new ClaimsPrincipal(identity));
        //
        //    if (!string.IsNullOrEmpty(returnUrl))
        //        return RedirectToAction(returnUrl);
        //   
        //    return  RedirectToAction(nameof(HomeController.Index), "Home");
        //}
        //else
        //{
        //    ModelState.AddModelError("", "Invalid UserName or Password");
        //    return View();
        //}

        if (!ModelState.IsValid)
        {
            return View(userModel);
        }
        var result = await _signInManager.PasswordSignInAsync(userModel.Email, 
                                                                            userModel.Password, 
                                                                            userModel.RememberMe, 
                                                                            false);
        if (result.Succeeded)
        {

            return RedirectToLocal(returnUrl);
        }
        else
        {
            ModelState.AddModelError("", "Invalid UserName or Password");
            return View();
        }
    }
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    private IActionResult RedirectToLocal(string returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
