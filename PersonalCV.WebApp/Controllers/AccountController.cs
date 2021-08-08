using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PersonalCV.Core.Services;
using PersonalCV.WebApp.Models;

namespace PersonalCV.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SiteInfoService _siteInfoService;

        public AccountController(SiteInfoService siteInfoService)
        {
            _siteInfoService = siteInfoService;
        }

        #region Login
        [Route("Login")]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginViewModel login, string ReturnUrl = "/")
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (await _siteInfoService.IsUsernameExist(login.Username, login.Password))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "Admin"),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(7)
                };
                await HttpContext.SignInAsync(principal, properties);

                if (string.IsNullOrWhiteSpace(ReturnUrl) == false)
                {
                    return Redirect(ReturnUrl);
                }
                return Redirect("/");
            }

            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
            return View(login);
        }

        #endregion

        #region Logout
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion
    }
}