using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class IPTreatment : IIPTreatment
    {
        HttpClient client;
        public IPTreatment()
        {
            client = new HttpClient();
        }

        public TreatmentPlan FormulateTreatmentTimetable(PatientDetails patient)
        {
            throw new NotImplementedException();
        }

        public List<PatientDetails> GetAllPatientDetails()
        {
            String baseAddress = "https://localhost:44354/api/Patient/";

            HttpResponseMessage response = client.GetAsync(baseAddress + "GetPatientDetails").Result;
            List<PatientDetails> patientDetails;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                patientDetails = JsonConvert.DeserializeObject<List<PatientDetails>>(data);

                if (patientDetails == null)
                {
                    throw new Exception();
                }
                return patientDetails;
            }
            else
            {
                throw new Exception();
            }
        }

        public List<TreatmentPlan> GetAllTreatmentDetails()
        {
            String baseAddress = "https://localhost:44354/api/Treatment/";

            HttpResponseMessage response = client.GetAsync(baseAddress + "GetTreatmentDetails").Result;
            List<TreatmentPlan> treatmentPlan;


            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                treatmentPlan = JsonConvert.DeserializeObject<List<TreatmentPlan>>(data);

                if (treatmentPlan == null)
                {
                    throw new Exception();
                }
                return treatmentPlan;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
