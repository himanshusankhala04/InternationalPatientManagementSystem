using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using IPtreatmentmanagementPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class InsuranceClaimRepo : IInsuranceClaimRepo
    {
        TreatmentStatusContext _context;
        String baseAddress = "";
        HttpClient client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private IConfiguration _Configure { get; set; }

        public InsuranceClaimRepo(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, TreatmentStatusContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _context = context;
            _Configure = configuration;
            client = new HttpClient();
            baseAddress = _Configure.GetValue<string>("InsuranceClaimServiceUrl");
        }

        public async Task<List<InsurerDetails>> GetAllInsurerDetails()
        {
            //String baseAddress = "https://localhost:44332/api/InsuranceClaim/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(baseAddress + "api/InsuranceClaim/GetAllInsurerDetail");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<InsurerDetails>>();
            }
            else
            {
                throw new Exception();
            }

        }



        public int GetBalanceAmmount(int id, string InsuranceProvider)
        {
            //String baseAddress = "https://localhost:44332/api/InsuranceClaim/InitiateClaim";
            TreatmentStatus ts = _context.TreatmentStatuses.FirstOrDefault(x => x.Id == id);
            InitiateClaim ic = new InitiateClaim()
            {
                PatientName=ts.PatientName,
                Ailment=ts.Ailment,
                TreatmentPackageName=ts.TreatmentPackageName,
                InsurerName=InsuranceProvider
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(ic), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/InsuranceClaim/InitiateClaim", content).Result;
            int balance;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                balance = JsonConvert.DeserializeObject<int>(data);

                return balance;
            }
            else
            {
                throw new Exception();
            }
        }

        public InsurerDetails GetInsurerByPackageName(string insurerPackageName)
        {
            //String baseAddress = "https://localhost:44354/api/InsuranceClaim/";

            HttpResponseMessage response = client.GetAsync(baseAddress + "api/InsuranceClaim/GetInsurerByPackageName").Result;
            InsurerDetails insurer;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                insurer = JsonConvert.DeserializeObject<InsurerDetails>(data);

                if (insurer == null)
                {
                    throw new Exception();
                }

                return insurer;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
