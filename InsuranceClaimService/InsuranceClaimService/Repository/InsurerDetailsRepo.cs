using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceClaimService.Model;
using System.Net.Http;
using Newtonsoft.Json;
using IPTreatmentOfferingService.Model;

namespace InsuranceClaimService.Repository
{
    public class InsurerDetailsRepo : IInsurerDetailsRepo
    {
        String baseAddress = "https://localhost:44350/api/";
        HttpClient client;
        public InsurerDetailsRepo()
        {
            client = new HttpClient();
        }

        private List<InsurerDetail> _insurerDetails = new List<InsurerDetail>()
        {
            new InsurerDetail
            {
                InsurerName = "Insurer Name 1",
                InsurerPackageName = "Insurance Package 1",
                InsuranceAmountLimit = 1000,
                DisbursementDuration = 10
            },
            new InsurerDetail
            {
                InsurerName = "Insurer Name 2",
                InsurerPackageName = "Insurance Package 2",
                InsuranceAmountLimit = 1500,
                DisbursementDuration = 5
            },
            new InsurerDetail
            {
                InsurerName = "Insurer Name 3",
                InsurerPackageName = "Insurance Package 3",
                InsuranceAmountLimit = 1200,
                DisbursementDuration = 7
            },
            new InsurerDetail
            {
                InsurerName = "Insurer Name 4",
                InsurerPackageName = "Insurance Package 4",
                InsuranceAmountLimit = 2000,
                DisbursementDuration = 3
            },
        };

        public int GetBalanceAmount(InitiateClaim initiateClaim)
        {
            IPTreatmentPackage treatmentPackage;
            var insurer = _insurerDetails.FirstOrDefault(p => p.InsurerName.ToLower() == initiateClaim.InsurerName.ToLower());
            if (insurer == null)
            {
                throw new Exception();
            }
            HttpResponseMessage response = client.GetAsync(baseAddress + "IPTreatment/IPTreatmentPackageByNameAndAilment/"+initiateClaim.TreatmentPackageName+"/"+initiateClaim.Ailment).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                
                treatmentPackage = JsonConvert.DeserializeObject<IPTreatmentPackage>(data);
                
                if (treatmentPackage == null)
                {
                    throw new Exception();
                }

                return Math.Abs(treatmentPackage.Cost - insurer.InsuranceAmountLimit);
             }
            else
            {
                throw new Exception();
            }


        }

        public List<InsurerDetail> GetDetails()
        {
            return _insurerDetails;
        }

        public InsurerDetail GetInsurer(string insurancePackageName)
        {
            return _insurerDetails.FirstOrDefault(p => p.InsurerPackageName.ToLower() == insurancePackageName.ToLower());
        }
    }
}
