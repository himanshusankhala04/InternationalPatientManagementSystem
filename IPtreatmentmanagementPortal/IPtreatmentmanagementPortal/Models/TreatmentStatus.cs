using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;

namespace IPtreatmentmanagementPortal.Models
{
    public class TreatmentStatus
    {
        public int Id { get; set; }
        public String PatientName { get; set; }
        public AilmentCategory Ailment { get; set; }
        public String TreatmentPackageName { get; set; }
        public String SpecialistName { get; set; }
        public DateTime TreatmentComencementDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
        public int Cost { get; set; }
        public bool Status { get; set; }
        public int BalanceAmount { get; set; }

    }
}
