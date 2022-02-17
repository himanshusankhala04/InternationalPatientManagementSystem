using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using IPtreatmentmanagementPortal.Model;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace IPtreatmentmanagementPortal.Repository
{
    public class JWT
    {
        public string Token { get; set; }
    }
    public class AuthorizationRepo : IAuthorizationRepo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        HttpClient client;
        string endpoint = "";

        private IConfiguration _Configure { get; set; }
        public AuthorizationRepo(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _Configure = configuration;
            client = new HttpClient();
            endpoint = _Configure.GetValue<string>("AuthorizationServiceUrl");

            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
        public string LoginService(AdminDetails admin)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");
            //string endpoint = "https://localhost:44335/api/Auth/login";

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            var Response = client.PostAsync(endpoint+ "api/Auth/login", content);
            
                var result = Response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var stringJWT = result.Content.ReadAsStringAsync().Result;
                    JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);
                    //HttpContext.Session.SetString("token", jwt.Token);
                    _httpContextAccessor.HttpContext.Session.SetString("token", jwt.Token);
                    return "success";
                }
                else
                    return null;
            
            
        }
    }
}
