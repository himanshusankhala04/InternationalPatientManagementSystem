using IpTreatmentOffering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpTreatmentOffering.Repository
{
    interface ISpecialistDetailsRepo
    {
        public List<SpecialistDetails> GetDetails();
    }
}
