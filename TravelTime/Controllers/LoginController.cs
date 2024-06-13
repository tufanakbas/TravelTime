using DataAccessLayer.Concrete;

using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TravelTime.Models;

namespace TravelTime.Controllers
{   
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignUp() // Register işlemleri
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p); // Return the same view with validation errors displayed
            }

            if (p.Password != p.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View(p);
            }

            var appUser = new AppUser
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username,
                ImageURL = p.ImageURL,
            };

            var result = await _userManager.CreateAsync(appUser, p.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "Member");
                TempData["SuccessMessage"] = "Registration successful! Please log in.";
                return RedirectToAction("SignIn");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(UserSignInViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.username, model.password,false,true);
                if(result.Succeeded)
                {
                    var userId=_userManager.Users.Where(x=>x.UserName== model.username).Select(y=>y.Id).FirstOrDefault();
                    
                    using(var context=new Context())
                    {
                        var userRoleId=context.UserRoles.Where(x=>x.UserId.Equals(userId)).Select(y=>y.RoleId).FirstOrDefault();
                        var adminRoleId = _roleManager.Roles.Where(x => x.Name.Equals("Admin") || x.Name.Equals("admin")).Select(y => y.Id).FirstOrDefault();

                        if(userRoleId==adminRoleId) // eğer giriş yapan kullanıcının rol id'si Admin rolünün id'sine eşit ise Admin paneline gitsin
                        {
                            return RedirectToRoute(new { action = "Index", controller = "Dashboard", area = "Admin" });
                        }
                        else
                        {
                            return RedirectToRoute(new { action = "MemberDashboard", controller = "Dashboard", area = "Member" });
                        }
                    }
                }
                else
                {
                    return RedirectToAction("SignIn","Login");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
