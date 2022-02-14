using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceClaimService.Model;

namespace InsuranceClaimService.Repository
{
    public interface IInsurerDetailsRepo
    {
        public List<InsurerDetail> GetDetails();
        public InsurerDetail GetInsurer(String insurancePackageName);

        public int GetBalanceAmount(InitiateClaim initiateClaim);
    }
}
