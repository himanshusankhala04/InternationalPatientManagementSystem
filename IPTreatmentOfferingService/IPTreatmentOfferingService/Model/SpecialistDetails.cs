using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IPTreatmentOfferingService.Model.IPTreatmentPackage;

namespace IPTreatmentOfferingService.Model
{
    public class SpecialistDetails
    {
        public int Specialist_Id { get; set; }
        public string Name { get; set; }
        public AilmentCategory AreaOfExpertise { get; set; }
        public int ExperienceInYears { get; set; }
        public int ContactNumber { get; set; }
    }
}
