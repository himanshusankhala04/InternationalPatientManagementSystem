using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;

namespace IPtreatmentmanagementPortal.Repository
{
    public interface IInsuranceClaimRepo
    {
        public List<InsurerDetails> GetAllInsurerDetails();
        public InsurerDetails GetInsurerByPackageName(String insurerPackageName);
        public int GetBalanceAmmount(InitiateClaim initiateClaim);
    }
}
