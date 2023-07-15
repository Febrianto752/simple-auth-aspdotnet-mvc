using AuthMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AuthMVC.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            Console.WriteLine("Role : " + claimUser.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value); // output : User
            Console.WriteLine("Email : " + claimUser.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value); // output : user@gmail.com
            Console.WriteLine("Name : " + claimUser.Claims?.FirstOrDefault(x => x.Type == "Name")?.Value); // output : febrianto
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }
    }
}