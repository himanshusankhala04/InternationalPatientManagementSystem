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
    public class IPTreatmentOfferingRepo : IIPTreatmentOfferingRepo
    {
        HttpClient client;
        
        public IPTreatmentOfferingRepo()
        {
           client = new HttpClient();
        }

        public async Task<List<IPTreatmentPackage>> GetAllIPTreatmentPackages()
        {
            String baseAddress = "https://localhost:44350/api/IPTreatment/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(baseAddress+"IPTreatmentPackages");


            if (response.IsSuccessStatusCode)
            {

                return await response.Content.ReadAsAsync<List<IPTreatmentPackage>>();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<SpecialistDetails>> GetAllSpecialistDetails()
        {
            String baseAddress = "https://localhost:44350/api/SpecialistDetails/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(baseAddress+"GetAllSpecialistDetails");

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
