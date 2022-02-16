using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using IPtreatmentmanagementPortal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPtreatmentmanagementPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthorizationRepo _authRepo;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public LoginController(IHttpContextAccessor httpContextAccessor, IAuthorizationRepo authRepo)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;

            _authRepo = authRepo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            AdminDetails admin = new AdminDetails();
            return View(admin);

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AdminDetails admin)
        {
            IActionResult response = Unauthorized();
            String success = _authRepo.LoginService(admin);
            if (success != null)
            {
                ViewBag.Message = "User logged in successfully!";
                return RedirectToAction("Index", "IPTreatmentManagementPortal", new { area = ""});
            }
            return View();
        }
    }
}
