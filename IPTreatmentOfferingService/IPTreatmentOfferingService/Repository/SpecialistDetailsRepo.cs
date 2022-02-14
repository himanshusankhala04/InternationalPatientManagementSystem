using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTreatmentOfferingService.Model;
using static IPTreatmentOfferingService.Model.IPTreatmentPackage;

namespace IPTreatmentOfferingService.Repository
{
    public class SpecialistDetailsRepo : ISpecialistDetailsRepo
    {
        private List<SpecialistDetails> _specialistDetails = new List<SpecialistDetails>()
        {
            new SpecialistDetails
            {
                Specialist_Id=1,
                Name="Name 1",
                AreaOfExpertise=AilmentCategory.Orthopaedics,
                ExperienceInYears=7,
                ContactNumber=1234567890
            },
            new SpecialistDetails
            {
                Specialist_Id=2,
                Name="Name 2",
                AreaOfExpertise=AilmentCategory.Urology,
                ExperienceInYears=6,
                ContactNumber=1234567890
            },
            new SpecialistDetails
            {
                Specialist_Id=3,
                Name="Name 3",
                AreaOfExpertise=AilmentCategory.Orthopaedics,
                ExperienceInYears=10,
                ContactNumber=1234567890
            },
            new SpecialistDetails
            {
                Specialist_Id=4,
                Name="Name 4",
                AreaOfExpertise = AilmentCategory.Urology,
                ExperienceInYears=12,
                ContactNumber=1234567890
            }
        };
        public List<SpecialistDetails> GetDetails()
        {
            return _specialistDetails;
        }
    }
}
