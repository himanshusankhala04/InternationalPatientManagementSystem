using IPTreatmentOfferingService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IPTreatmentOfferingService.Model.IPTreatmentPackage;

namespace IPTreatmentOfferingService.Repository
{
     interface IIPTreatmentPackageRepo
    {
        public List<IPTreatmentPackage> GetDetails();
        public IPTreatmentPackage GetDteailsByName(String name);
        public IPTreatmentPackage GetDteailsByNameAndAilment(String name, AilmentCategory ailment);
    }
}
