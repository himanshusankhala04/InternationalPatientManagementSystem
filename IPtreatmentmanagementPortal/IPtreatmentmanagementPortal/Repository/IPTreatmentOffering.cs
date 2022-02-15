using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class IPTreatmentOffering : IIPTreatmentOffering
    {
        HttpClient client;
        public IPTreatmentOffering()
        {
            client = new HttpClient();
        }

        public List<IPTreatmentPackage> GetAllIPTreatmentPackages()
        {
            String baseAddress = "https://localhost:44354/api/IPTreatmentOfferingService";

            HttpResponseMessage response = client.GetAsync(baseAddress + "IPTreatmentPackages").Result;
            List<IPTreatmentPackage> treatmentPackages;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                treatmentPackages = JsonConvert.DeserializeObject<List<IPTreatmentPackage>>(data);

                if (treatmentPackages == null)
                {
                    throw new Exception();
                }
                return treatmentPackages;
            }
            else
            {
                throw new Exception();
            }
        }

        public List<SpecialistDetails> GetAllSpecialistDetails()
        {
            String baseAddress = "https://localhost:44354/api/IPTreatmentOfferingService";

            HttpResponseMessage response = client.GetAsync(baseAddress + "GetAllSpecialistDetails").Result;
            List<SpecialistDetails> specialists;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                specialists = JsonConvert.DeserializeObject<List<SpecialistDetails>>(data);

                if (specialists == null)
                {
                    throw new Exception();
                }
                return specialists;
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
