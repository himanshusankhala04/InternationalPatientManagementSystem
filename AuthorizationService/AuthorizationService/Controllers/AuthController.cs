using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Model;
using AuthorizationService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private AuthRepo _authRepo;

        public AuthController(AuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] AdminDetails admin)
        {

            IActionResult response = Unauthorized();
            var obj = _authRepo.AuthenticateAdmin(admin);
            if (obj != null)
            {
                var tokenString = _authRepo.GenerateJSONWebToken(admin);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
