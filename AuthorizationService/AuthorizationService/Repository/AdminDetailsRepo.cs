using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Model;
using Microsoft.Extensions.Configuration;

namespace AuthorizationService.Repository
{
    public class AdminDetailsRepo : IAdminDetailsRepo
    {
        private static List<AdminDetails> _admins = new List<AdminDetails>
                    {
                        new AdminDetails {
                            UserName = "user1",
                            Password = "user1"
                        },
                        
                        new AdminDetails
                        {
                            UserName = "admin1",
                            Password = "pass1"
                        },
                    };
        
        
        public List<AdminDetails> GetAdminDetails()
        {
            return _admins;
        }
    }
}
