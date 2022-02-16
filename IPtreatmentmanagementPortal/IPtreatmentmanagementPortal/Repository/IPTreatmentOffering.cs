using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class IPTreatmentOffering : IIPTreatmentOffering
    {
        HttpClient client;
        
        public IPTreatmentOffering()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }

        public List<IPTreatmentPackage> GetAllIPTreatmentPackages()
        {
            String baseAddress = "https://localhost:25257/api/IPTreatment/";
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("IPTreatmentPackages").Result;

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

        public async Task<List<SpecialistDetails>> GetAllSpecialistDetails()
        {
            String baseAddress = "https://localhost:25257/api/SpecialistDetails/";
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("GetAllSpecialistDetails");

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
