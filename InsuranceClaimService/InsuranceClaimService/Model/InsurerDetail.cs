using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimService.Model
{
    public class InsurerDetail
    {
        public int InsurerId { get; set; }
        public String InsurerName { get; set; }
        public String InsurerPackageName { get; set; }
        public int InsuranceAmountLimit { get; set; }
        public int DisbursementDuration { get; set; }

    }
}
