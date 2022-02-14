using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Model;

namespace AuthorizationService.Repository
{
    public interface IAdminDetailsRepo
    {
        public List<AdminDetails> GetAdminDetails();
    }
}
