using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class IPTreatmentRepo : IIPTreatmentRepo
    {
        HttpClient client;
        public IPTreatmentRepo()
        {
            client = new HttpClient();
        }

        public TreatmentPlan FormulateTreatmentTimetable(PatientDetails patient)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PatientDetails>> GetAllPatientDetails()
        {
            String baseAddress = "https://localhost:44366/api/Patient/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(baseAddress + "GetPatientDetails");
           
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
            String baseAddress = "https://localhost:44366/api/Treatment/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(baseAddress + "GetTreatmentDetails");
            

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
