using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentOfferingService.Model
{
    public class IPTreatmentPackage
    {
        public int TreatmentPackageID { get; set; }
        public enum AilmentCategory
        {
            Orthopaedics,
            Urology
        }
        public AilmentCategory AilmentCategory1 { get; set; }
        public string TreatmentPackageName { get; set; }
        public string TestDetails { get; set; }
        public int Cost { get; set; }
        public int TreatmentDuration { get; set; }
    }
}
