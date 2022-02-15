using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPtreatmentmanagementPortal.Model
{
    public class InsurerDetails
    {
        public int InsurerId { get; set; }
        public String InsurerName { get; set; }
        public String InsurerPackageName { get; set; }
        public int InsuranceAmountLimit { get; set; }
        public int DisbursementDuration { get; set; }

    }
}
