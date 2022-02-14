using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTreatmentService.Model;

namespace IPTreatmentService.Repository
{
    public interface ITreatmentPlanRepo
    {
        public List<TreatmentPlan> GetDetails();
    }
}
