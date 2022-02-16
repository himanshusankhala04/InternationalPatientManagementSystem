using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;

namespace IPtreatmentmanagementPortal.Repository
{
     public interface IIPTreatmentOffering
    {
        public List<IPTreatmentPackage> GetAllIPTreatmentPackages();
        public IPTreatmentPackage GetIPTreatmentPackageByName(string name);
        public IPTreatmentPackage GetIPTreatmentPackageByNameAndAilment(string name, AilmentCategory ailment);
        public Task<List<SpecialistDetails>> GetAllSpecialistDetails();
    }
}
