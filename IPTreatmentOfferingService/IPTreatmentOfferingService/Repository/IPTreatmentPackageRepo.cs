using IPTreatmentOfferingService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IPTreatmentOfferingService.Model.IPTreatmentPackage;

namespace IPTreatmentOfferingService.Repository
{
    public class IPTreatmentPackageRepo : IIPTreatmentPackageRepo
    {
        private List<IPTreatmentPackage> _iPTreatmentPackages = new List<IPTreatmentPackage>()
        {
            new IPTreatmentPackage
            {
                TreatmentPackageID=1,
                AilmentCategory1=AilmentCategory.Orthopaedics,
                TreatmentPackageName="Package 1",
                TestDetails="OPT 1,OPT 2",
                Cost=2500,
                TreatmentDuration=4
            },
            new IPTreatmentPackage
            {
                TreatmentPackageID=2,
                AilmentCategory1=AilmentCategory.Urology,
                TreatmentPackageName="Package 2",
                TestDetails="OPT 3,OPT 4",
                Cost=4000,
                TreatmentDuration=4
            },
            new IPTreatmentPackage
            {
                TreatmentPackageID=1,
                AilmentCategory1=AilmentCategory.Orthopaedics,
                TreatmentPackageName="Package 1",
                TestDetails="OPT 1,OPT 2",
                Cost=3000,
                TreatmentDuration=6
            },
            new IPTreatmentPackage
            {
                TreatmentPackageID=1,
                AilmentCategory1=AilmentCategory.Urology,
                TreatmentPackageName="Package 2",
                TestDetails="OPT 1,OPT 2",
                Cost=5000,
                TreatmentDuration=6
            }
        };
        public List<IPTreatmentPackage> GetDetails()
        {
            return _iPTreatmentPackages;
        }

        public IPTreatmentPackage GetDteailsByName(String Name)
        {
            var obj = _iPTreatmentPackages.FirstOrDefault(x => x.TreatmentPackageName.ToLower() == Name.ToLower());
            if(obj == null)
            {
                return null;
            }
            return obj;
        }
    }
}
