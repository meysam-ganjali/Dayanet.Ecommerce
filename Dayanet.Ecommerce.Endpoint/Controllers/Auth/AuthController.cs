using Dayanet.Ecommerce.Application.FASADE.Users;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Azure.Core;

namespace Dayanet.Ecommerce.Endpoint.Controllers.Auth {
    public class AuthController : Controller {
        private readonly IUserFasade _userService;

        public AuthController(IUserFasade userService) {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Signup(string? returnUrl = null) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(CreateUserDto request) {

            if (request.PasswordHash != request.ConfirmPassword) {
                ModelState.AddModelError(string.Empty, "کلمه عبور با تکرار آن برابر نیست");
                return View();
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "ارسال پارامتر نا معنبر");
                return View();
            }
            var signeupResult = await _userService.RegisterService.RegisterAsync(request);

            if (signeupResult.IsSuccess == true) {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signeupResult.Data.Id.ToString()),
                new Claim(ClaimTypes.Email, signeupResult.Data.Email),
                new Claim(ClaimTypes.Name, signeupResult.Data.FullName),
                new Claim(ClaimTypes.MobilePhone, signeupResult.Data.CellPhone),
                new Claim(ClaimTypes.Role, SD.Customer),
            };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties() {
                    IsPersistent = true
                };
               // HttpContext.SignInAsync(principal, properties);

            }
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null) {
            returnUrl ??= Url.Content("~/");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto request, string? returnUrl = null) {
            returnUrl ??= Url.Content("~/");
          
            if (ModelState.IsValid)
            {
                var signupResult = await _userService.LoginService.LoginAsync(request);
                if (signupResult.IsSuccess == true) {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,signupResult.Data.Id.ToString()),
                        new Claim(ClaimTypes.Email, signupResult.Data.Email),
                        new Claim(ClaimTypes.Name, signupResult.Data.FullName),
                        new Claim(ClaimTypes.MobilePhone, signupResult.Data.CellPhone),
                        new Claim(ClaimTypes.Role, signupResult.Data.RoleName),
                    };
                    AuthenticationProperties properties;

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    if (request.IsMemberMe) {
                        properties = new AuthenticationProperties() {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddDays(5),
                        };
                    } else {
                        properties = new AuthenticationProperties() {
                            IsPersistent = true,
                        };
                    }

                    HttpContext.SignInAsync(principal, properties);
                    return LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "ارسال پارامتر نا معنبر");
            return View();
        }


        public IActionResult SignOut() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
