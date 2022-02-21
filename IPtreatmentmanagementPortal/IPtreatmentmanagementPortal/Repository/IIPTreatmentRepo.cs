using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using IPtreatmentmanagementPortal.Models;

namespace IPtreatmentmanagementPortal.Repository
{
    public interface IIPTreatmentRepo
    {
        public Task<List<PatientDetails>> GetAllPatientDetails();
        public Task<List<TreatmentPlan>> GetAllTreatmentDetails();
        public void FormulateTreatmentTimetable(PatientDetails patient);

        public List<TreatmentStatus> GetAllTreatmentStatus();
        public void UpdateTreatmentStatus(int id, int balance);
    }
}
