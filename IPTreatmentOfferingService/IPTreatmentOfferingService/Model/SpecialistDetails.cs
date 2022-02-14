using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentOfferingService.Model
{
    public class SpecialistDetails
    {
        public int Specialist_Id { get; set; }
        public string Name { get; set; }
        public string AreaOfExpertise { get; set; }
        public int ExperienceInYears { get; set; }
        public int ContactNumber { get; set; }
    }
}
