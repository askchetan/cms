using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;
using CMS.DataAccess;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CMS.Controllers
{
    public class HomeController : BaseController
    {
        private readonly CMSDbContext _cMSDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(CMSDbContext cMSDbContext, ILogger<HomeController> logger)
           : base(cMSDbContext)
        {
            _cMSDbContext = cMSDbContext;
            _logger = logger;
        }

        public IActionResult Index(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
            {
                pageName = "/";
            }
            var page = _cMSDbContext.Pages.FirstOrDefault(p => p.Url == pageName);
            if (page == null)
            {
                pageName = "/";
                page = _cMSDbContext.Pages.FirstOrDefault(p => p.Url == pageName);
            }
            ViewData["Title"] = $"{CommonData.Instance.GetValue("CompanyName")} - {page.Name}";
            var seo = _cMSDbContext.PageSEOs.FirstOrDefault(ps => ps.PageId == page.PageId);
            ViewData["MetaDescription"] = seo?.MetaDescription ?? $"{CommonData.Instance.GetValue("CompanyName")} - {page.Name}";
            ViewData["MetaTags"] = seo?.MetaTag ?? page.Name;

            page.Paragraphs = _cMSDbContext.Paragraph.Where(p => p.PageId == page.PageId).ToList();
            ViewData["Products"] = _cMSDbContext.Products.OrderBy(p => p.DisplayOrder).ToList();
            return View(page);
        }

        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout(string returnURL)
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] LoginModel loginData)
        {
            if (ModelState.IsValid)
            {

                var isValid = (loginData.Username == CommonData.Instance.GetValue("AdminUser") 
                    && loginData.Password == CommonData.Instance.GetValue("AdminPassword"));
                if (!isValid)
                {
                    ModelState.AddModelError("", "username or password is invalid");
                    return View();
                }
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginData.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, loginData.Username));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
                return Redirect("~/Admin/Pages");
            }
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
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
