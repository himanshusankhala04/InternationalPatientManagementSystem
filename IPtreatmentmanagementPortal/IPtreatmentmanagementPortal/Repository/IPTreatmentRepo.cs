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
    public class IPTreatmentRepo : IIPTreatmentRepo
    {
        HttpClient client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        String baseAddress = "";
        private IConfiguration _Configure { get; set; }
        public IPTreatmentRepo(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            baseAddress = _Configure.GetValue<string>("IPTreatmentServiceUrl");
            _Configure = configuration;
            client = new HttpClient();
        }

        public TreatmentPlan FormulateTreatmentTimetable(PatientDetails patient)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PatientDetails>> GetAllPatientDetails()
        {
            //String baseAddress = "https://localhost:44366/api/Patient/";
            //String baseAddress = "https://iptreatmentsercvice.azurewebsites.net/api/Patient/";
        
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(baseAddress  + "api/Patient/GetPatientDetails");
           
            if (response.IsSuccessStatusCode)
            {

                return await response.Content.ReadAsAsync<List<PatientDetails>>();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<TreatmentPlan>> GetAllTreatmentDetails()
        {
            //String baseAddress = "https://localhost:44366/api/Treatment/";
            //String baseAddress = "https://iptreatmentsercvice.azurewebsites.net/api/Treatment/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(baseAddress + "api/Treatment/GetTreatmentDetails");
            

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<TreatmentPlan>>();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
