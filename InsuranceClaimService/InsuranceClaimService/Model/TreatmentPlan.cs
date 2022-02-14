using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimService.Model
{
    //added
   
    public class TreatmentPlan
    {
        public int TreatmentId { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public int Cost { get; set; }
        public string Specialist { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
        //added
        public AilmentCategory Ailment { get; set; }
        public DateTime TreatmentEndDate { get; set; }
    }
}
