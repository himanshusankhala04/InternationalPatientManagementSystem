using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using Newtonsoft.Json;

namespace IPtreatmentmanagementPortal.Repository
{
    public class IPTreatment : IIPTreatment
    {
        public TreatmentPlan FormulateTreatmentTimetable(PatientDetails patient)
        {
            throw new NotImplementedException();
        }

        public List<PatientDetails> GetAllPatientDetails()
        {
            throw new NotImplementedException();
        }

        public List<TreatmentPlan> GetAllTreatmentDetails()
        {
            throw new NotImplementedException();
        }
    }
}
