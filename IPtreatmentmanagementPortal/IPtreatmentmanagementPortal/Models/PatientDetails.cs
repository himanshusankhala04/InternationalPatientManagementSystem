using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPtreatmentmanagementPortal.Model
{
    public class PatientDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public AilmentCategory Ailment { get; set; }
        public string TreatmentPackageName { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
    }
}
