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
    public class IPTreatmentRepo : IIPTreatmentRepo
    {
        TreatmentStatusContext _context;
        HttpClient client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        String baseAddress = "";
        private IConfiguration _Configure { get; set; }
        public IPTreatmentRepo(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, TreatmentStatusContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;


            _Configure = configuration;
            client = new HttpClient();
            _context = context;
        }

        public void FormulateTreatmentTimetable(PatientDetails patient)
        {
            baseAddress = _Configure.GetValue<string>("IPTreatmentServiceUrl");
            StringContent content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/Treatment/api/Treatment/FormulateTreatmentTimetable", content).Result;

            if (response.IsSuccessStatusCode)
            {
                TreatmentPlan tp = response.Content.ReadAsAsync<TreatmentPlan>().Result;
                TreatmentStatus ts = new TreatmentStatus()
                {
                    PatientName = patient.Name,
                    Ailment = patient.Ailment,
                    TreatmentPackageName = patient.TreatmentPackageName,
                    SpecialistName = tp.Specialist,
                    TreatmentComencementDate = patient.TreatmentCommencementDate,
                    TreatmentEndDate = tp.TreatmentEndDate,
                    Cost = tp.Cost,
                    Status = true,
                    BalanceAmount = 0
                };

                _context.TreatmentStatuses.Add(ts);
                _context.SaveChanges();

            }
            else
            {
                throw new Exception();
            }
        }
        public List<TreatmentStatus> GetAllTreatmentStatus()
        {
            return _context.TreatmentStatuses.ToList();
           
        }

        public void UpdateTreatmentStatus(int id, int balance)
        {
            TreatmentStatus ts = _context.TreatmentStatuses.FirstOrDefault(x => x.Id == id);
            ts.Status = false;
            ts.BalanceAmount = balance;
            _context.SaveChanges();
        }




        public async Task<List<PatientDetails>> GetAllPatientDetails()
        {

            baseAddress = _Configure.GetValue<string>("IPTreatmentServiceUrl");
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

            baseAddress = _Configure.GetValue<string>("IPTreatmentServiceUrl");
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
