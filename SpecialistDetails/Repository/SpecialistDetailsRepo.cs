using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpTreatmentOffering.Model;

namespace IpTreatmentOffering.Repository
{
    public class SpecialistDetailsRepo : ISpecialistDetailsRepo
    {
        private List<SpecialistDetails> _specialistDetails = new List<SpecialistDetails>()
        {
            new SpecialistDetails
            {
                Specialist_Id=1,
                Name="Name 1",
                AreaOfExpertise="Orthopedics",
                ExperienceInYears=10,
                ContactNumber=1234567890
            },
            new SpecialistDetails
            {
                Specialist_Id=2,
                Name="Name 2",
                AreaOfExpertise=" Urology",
                ExperienceInYears=11,
                ContactNumber=1234567890
            },
            new SpecialistDetails
            {
                Specialist_Id=3,
                Name="Name 3",
                AreaOfExpertise="Orthopedics",
                ExperienceInYears=9,
                ContactNumber=1234567890
            },
            new SpecialistDetails
            {
                Specialist_Id=4,
                Name="Name 4",
                AreaOfExpertise="Urology",
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
