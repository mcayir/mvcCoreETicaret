using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using mvcCoreETicaret.Northwind.MvcWebUI.Entities;
using mvcCoreETicaret.Northwind.MvcWebUI.Models;

namespace mvcCoreETicaret.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
            private UserManager<CustomIdentityUser> _userManager;
            private RoleManager<CustomIdentityRole> _roleManager;
            private SignInManager<CustomIdentityUser> _signInManager;

            public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _signInManager = signInManager;
            }

            public ActionResult Register()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Register(RegisterViewModel registerViewModel)
            {
                if (ModelState.IsValid)
                {
                    CustomIdentityUser user = new CustomIdentityUser
                    {
                        UserName = registerViewModel.UserName,
                        Email = registerViewModel.Email
                    };

                    IdentityResult result =
                        _userManager.CreateAsync(user, registerViewModel.Password).Result;

                    if (result.Succeeded)
                    {
                        if (!_roleManager.RoleExistsAsync("Kullanıcı").Result)
                        {
                            CustomIdentityRole role = new CustomIdentityRole
                            {
                                Name = "Kullanıcı"
                            };

                            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                            if (!roleResult.Succeeded)
                            {
                                ModelState.AddModelError("", "Böyle bir Rol eklenemez");
                                return View(registerViewModel);
                            }
                        }

                        _userManager.AddToRoleAsync(user, "Kullanıcı").Wait();
                        return RedirectToAction("Login", "Account");
                    }
                }

                return View(registerViewModel);
            }

            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(LoginViewModel loginViewModel)
            {
                if (ModelState.IsValid)
                {
                    var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                        loginViewModel.Password, loginViewModel.RememberMe, false).Result;

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    ModelState.AddModelError("", "Giriş Hatalı Lütfen Tekrar Deneyiniz");
                }

                return View(loginViewModel);
            }

          
            public ActionResult LogOff()
            {
                _signInManager.SignOutAsync().Wait();
                return RedirectToAction("Login");
            }
        }
}