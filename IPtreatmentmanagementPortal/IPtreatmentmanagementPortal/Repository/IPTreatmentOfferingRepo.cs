using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class IPTreatmentOfferingRepo : IIPTreatmentOfferingRepo
    {
        HttpClient client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private IConfiguration _Configure { get; set; }
        String baseAddress = "";
        public IPTreatmentOfferingRepo(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;

            _Configure = configuration;

            baseAddress = _Configure.GetValue<string>("IPTreatmentOfferingServiceUrl");
            client = new HttpClient();
        }

        public async Task<List<IPTreatmentPackage>> GetAllIPTreatmentPackages()
        {
            //String baseAddress = "https://localhost:44350/api/IPTreatment/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(baseAddress+ "api/IPTreatment/IPTreatmentPackages");


            if (response.IsSuccessStatusCode)
            {

                return await response.Content.ReadAsAsync<List<IPTreatmentPackage>>();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<SpecialistDetails>> GetAllSpecialistDetails()
        {
            //String baseAddress = "https://localhost:44350/api/SpecialistDetails/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(baseAddress+ "api/SpecialistDetails/GetAllSpecialistDetails");

            if (response.IsSuccessStatusCode)
            {
                
                return await response.Content.ReadAsAsync<List<SpecialistDetails>>();
            }
            else
            {
                throw new Exception();
            }
        }

        public IPTreatmentPackage GetIPTreatmentPackageByName(string name)
        {
            throw new NotImplementedException();
        }

        public IPTreatmentPackage GetIPTreatmentPackageByNameAndAilment(string name, AilmentCategory ailment)
        {
            throw new NotImplementedException();
        }
        
    }
}
