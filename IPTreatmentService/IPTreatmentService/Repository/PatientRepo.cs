using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTreatmentService.Model;

namespace IPTreatmentService.Repository
{
    public class PatientRepo : IPatientRepo 
    {

        private List<PatientDetail> _PatientDetail = new List<PatientDetail>()
        {
            new PatientDetail
            {
                Name = "Name1",
                Age = 20,
                Ailment= true,

                TreatmentPackageName = "Package1",

                TreatmentCommencementDate = DateTime.Now,
            }
        };
        public List<PatientDetail> GetDetails()
        {

            return _PatientDetail;
        }
    }
}
