using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationService.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthorizationService.Repository
{
    public class AuthRepo
    {
        private readonly IConfiguration _config;
        private readonly IAdminDetailsRepo _admin;

        public AuthRepo(IConfiguration config, IAdminDetailsRepo admin)
        {
            _config = config;
            _admin = admin;
        }

        public string GenerateJSONWebToken(AdminDetails userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        public AdminDetails AuthenticateAdmin(AdminDetails admin)
        {
            
            AdminDetails obj = _admin.GetAdminDetails().FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(obj == null)
            {
                return null;
            }
            return obj;
        }

    }
}
