using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;

namespace IPtreatmentmanagementPortal.Repository
{
    public interface IIPTreatment
    {
        public List<PatientDetails> GetAllPatientDetails();
        public List<TreatmentPlan> GetAllTreatmentDetails();
        public TreatmentPlan FormulateTreatmentTimetable(PatientDetails patient);
        
    }
}
