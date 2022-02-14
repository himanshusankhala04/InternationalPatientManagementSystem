using IPTreatmentOfferingService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentOfferingService.Repository
{
    interface ISpecialistDetailsRepo
    {
        public List<SpecialistDetails> GetDetails();
    }
}
