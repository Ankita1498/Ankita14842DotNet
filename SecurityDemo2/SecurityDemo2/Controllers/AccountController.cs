using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecurityDemo2.Models;
using SecurityDemo2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SecurityDemo2.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<MyIdentityUser> userManager;//Identity API used for creating and managing users
        private readonly SignInManager<MyIdentityUser> loginManager;//Identity API used to log a user in and out of the system
        private readonly RoleManager<MyIdentityRole> roleManager;//Identity API used for creating and managing roles

        public AccountController(UserManager<MyIdentityUser>userManager,
            SignInManager<MyIdentityUser> loginManager,
            RoleManager<MyIdentityRole>roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;

            AddAdmin();
        }
        private void AddAdmin()
        {
            if(!roleManager.RoleExistsAsync("admin").Result)
            {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "admin";
                role.Description = "administrator web site";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                if(!roleResult.Succeeded)
                {
                    ModelState.AddModelError("", "Error while creating role!");
                }
                else
                {
                    MyIdentityUser user = new MyIdentityUser();
                    user.UserName = "admin";
                    user.Email = "admin@test.com";
                    user.FullName = "site admin";
                    //user.BirthDate = obj.BirthDate;

                    IdentityResult result = userManager.CreateAsync(user, "test123").Result;

                    userManager.AddToRoleAsync(user, "admin").Wait();
                }
            }
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //user creation
        //role creation
        //assign role to user
        public IActionResult Register(RegisterViewModel obj)
        {
            if(ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.FullName = obj.FullName;
                user.BirthDate = obj.BirthDate;

                IdentityResult result = userManager.CreateAsync(user, obj.Password).Result;//create user

                if(result.Succeeded)
                {//assign role to user
                    if(!roleManager.RoleExistsAsync("NormalUser").Result)
                    {//if no then create
                        MyIdentityRole role = new MyIdentityRole();
                        role.Name = "NormalUser";
                        role.Description = "Perform normal operations.";
                        IdentityResult roleResult = roleManager.CreateAsync(role).Result;//create role
                        if(!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Error while creating role!");
                            return View(obj); //1
                        }
                    }
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();//assign role to user
                    return RedirectToAction("Login", "Account");//2
                }
                else
                {
                    IEnumerable<IdentityError> errors = result.Errors;
                    foreach(var item in errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(obj);//3         
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel obj)
        {
            if(ModelState.IsValid)
            {
                //PasswordSignInAsync(string username,string password,bool isPersistent,bool lockoutOnFailure)
                var result = loginManager.PasswordSignInAsync(obj.UserName, obj.Password, obj.RememberMe, true).Result;
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");//valid user
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login!"); //invalid username or password
                }

                if(result.IsLockedOut)
                {
                    ModelState.AddModelError("locker","Account is locked"); //more than 3 wrng attempts
                }
               
            }
            return View(obj); //failing server side Validation
        }

        public IActionResult LogOff()
        {
            loginManager.SignOutAsync().Wait();
            return RedirectToAction("Login", "Account");
        }

       [HttpGet]
       [AllowAnonymous]
       public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
