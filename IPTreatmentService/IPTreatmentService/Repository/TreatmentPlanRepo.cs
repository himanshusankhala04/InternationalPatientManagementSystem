using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IPTreatmentService.Model;
using Newtonsoft.Json;

namespace IPTreatmentService.Repository
{
    public class TreatmentPlanRepo : ITreatmentPlanRepo
    {
        String baseAddress = "http://localhost:25257/api/";
        HttpClient client;

        private List<TreatmentPlan> treatmentPlan;
        public TreatmentPlanRepo()
        {
            client = new HttpClient();
            if(treatmentPlan == null)
            {
                this.Initialize();
            }
            
        }

        public void Initialize()
        {
            treatmentPlan = new List<TreatmentPlan>()
            {
                new TreatmentPlan
                {
                    PackageName = "Package 1",
                    TestDetails = "OPT1, OPT2",
                    Cost= 2000,
                    Specialist = "SName1",
                    Ailment = AilmentCategory.Orthopaedics,
                    TreatmentCommencementDate = DateTime.Now,
                    TreatmentEndDate= DateTime.Today,
                },

            };
        }

        public List<TreatmentPlan> GetDetails()
        {
            return treatmentPlan;
        }

        public TreatmentPlan GetTreatmentPlan(PatientDetail patient)
        {
            IPTreatmentPackage treatmentPackage;
            SpecialistDetails specialist;
            HttpResponseMessage response = client.GetAsync(baseAddress + "IPTreatment/IPTreatmentPackageByNameAndAilment/"+ patient.TreatmentPackageName +"/" + patient.Ailment).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                treatmentPackage = JsonConvert.DeserializeObject<IPTreatmentPackage>(data);

                if (treatmentPackage == null)
                {
                    throw new Exception();
                }


            }
            else
            {
                throw new Exception();
            }

            HttpResponseMessage response2 = client.GetAsync(baseAddress + "SpecialistDetails/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response2.Content.ReadAsStringAsync().Result;

                var specialistDetails = JsonConvert.DeserializeObject<List<SpecialistDetails>>(data);

                if (treatmentPackage.TreatmentPackageName == "Package 1")
                {
                    specialist = specialistDetails.FirstOrDefault(x => x.ExperienceInYears <= 8 && x.AreaOfExpertise == treatmentPackage.Ailment);
                }else
                {
                    specialist = specialistDetails.FirstOrDefault(x => x.ExperienceInYears > 8 && x.AreaOfExpertise == treatmentPackage.Ailment);
                }
                if (specialist == null)
                {
                    throw new Exception();
                }

            }
            else
            {
                throw new Exception();
            }

            TreatmentPlan plan = new TreatmentPlan()
            {
                PackageName = patient.TreatmentPackageName,
                TestDetails = treatmentPackage.TestDetails,
                Cost = treatmentPackage.Cost,
                Specialist = specialist.Name,
                Ailment = patient.Ailment,
                TreatmentCommencementDate = patient.TreatmentCommencementDate,
                TreatmentEndDate = patient.TreatmentCommencementDate.AddDays((treatmentPackage.TreatmentDuration * 7)),
            };
            this.treatmentPlan.Add(plan);
            
            return plan;
        }
    }
}
