using BrainBox.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BrainBox.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = UserStore.Admins.Concat(UserStore.Clients).FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Role", user.Role)
            };

                var identity = new ClaimsIdentity(claims, "CookieAuth");

                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if username already exists
            if (UserStore.Admins.Concat(UserStore.Clients).Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("", "Username already exists.");
                return View(model);
            }

            // Add the new user
            var newUser = new User
            {
                Username = model.Username,
                Password = model.Password, // In a real application, you should hash the password
                Role = "Client" // Assuming all registered users are clients
            };

            UserStore.Clients.Add(newUser); // Add the user to your list of clients

            // Redirect to login page after successful registration
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }
    }
}
