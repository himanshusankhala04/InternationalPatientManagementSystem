using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentService.Model
{
    public class PatientDetail
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Ailment { get; set; }
        public string TreatmentPackageName { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
    }
}
