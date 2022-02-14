using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTreatmentService.Model;

namespace IPTreatmentService.Repository
{
    public class TreatmentPlanRepo : ITreatmentPlanRepo
    {
        private List<TreatmentPlan> treatmentplan = new List<TreatmentPlan>()
        {
            new TreatmentPlan
            {
                TreatmentId = 1,
                PackageName = "Package1",
                TestDetails = "OPT1, OPT2",
                Cost= 2000,
                Specialist = "SName1",
                Ailment = AilmentCategory.Orthopaedics,
                TreatmentCommencementDate = DateTime.Now,
                TreatmentEndDate= DateTime.Today,
            },
            new TreatmentPlan
            {
                TreatmentId = 2,
                PackageName = "Package2",
                TestDetails = "OPT3, OPT4",
                Cost= 2500,
                Specialist = "SName3",
                Ailment = AilmentCategory.Orthopaedics,
                TreatmentCommencementDate = DateTime.Now,
                TreatmentEndDate= DateTime.Today,
            },
            new TreatmentPlan
            {
                TreatmentId = 3,
                PackageName = "Package1",
                TestDetails = "OPT1, OPT2",
                Cost= 5000,
                Specialist = "SName2",
                TreatmentCommencementDate = DateTime.Now,
                Ailment = AilmentCategory.Urology,
                TreatmentEndDate= DateTime.Today,
            }
        };
        public List<TreatmentPlan> GetDetails()
        {
            return treatmentplan;
        }
    }
}
