using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsuranceClaimService.Model
{
    public enum AilmentCategory
    {
        Orthopaedics,
        Urology
    }
    public class InitiateClaim
    {
        public String PatientName { get; set; }

        public AilmentCategory Ailment { get; set; }
        public String TreatmentPackageName { get; set; }
        public String InsurerName { get; set; }

    }
}
