using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;

namespace IPtreatmentmanagementPortal.Repository
{
    public interface IIPTreatmentRepo
    {
        public Task<List<PatientDetails>> GetAllPatientDetails();
        public Task<List<TreatmentPlan>> GetAllTreatmentDetails();
        public TreatmentPlan FormulateTreatmentTimetable(PatientDetails patient);
        
    }
}
