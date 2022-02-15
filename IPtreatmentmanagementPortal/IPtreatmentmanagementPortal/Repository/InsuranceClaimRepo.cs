using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class InsuranceClaimRepo : IInsuranceClaimRepo
    {
        HttpClient client;
        public InsuranceClaimRepo()
        {
            client = new HttpClient();
        }

        public List<InsurerDetails> GetAllInsurerDetails()
        {
            String baseAddress = "https://localhost:44354/api/InsuranceClaimController/";

            HttpResponseMessage response = client.GetAsync(baseAddress + "GetAllInsurerDetail").Result;
            List<InsurerDetails> insuranceDetails;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                insuranceDetails = JsonConvert.DeserializeObject<List<InsurerDetails>>(data);

                if (insuranceDetails == null)
                {
                    throw new Exception();
                }

                return insuranceDetails;
            }
            else
            {
                throw new Exception();
            }

        }

        public int GetBalanceAmmount(InitiateClaim initiateClaim)
        {
            String baseAddress = "https://localhost:44354/api/InsuranceClaimController/";

            HttpResponseMessage response = client.GetAsync(baseAddress + "InitiateClaim").Result;
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
            String baseAddress = "https://localhost:44354/api/InsuranceClaimController/";

            HttpResponseMessage response = client.GetAsync(baseAddress + "GetInsurerByPackageName").Result;
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
