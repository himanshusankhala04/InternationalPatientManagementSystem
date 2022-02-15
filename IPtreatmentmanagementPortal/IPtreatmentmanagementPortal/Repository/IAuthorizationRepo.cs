using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Microsoft.AspNetCore.Mvc;

namespace IPtreatmentmanagementPortal.Repository
{
    public interface IAuthorizationRepo
    {
        public String LoginService(AdminDetails admin);


    }
}
