using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTreatmentService.Model;
using IPTreatmentService.Repository;

namespace IPTreatmentService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientRepo _patientobj;

        public PatientController(IPatientRepo patientobj)
        {
            _patientobj = patientobj;
        }


        [HttpGet]
        [Route(["action"])]
        public IActionResult GetPatientDetails()
        {
            List<PatientDetail> list = _patientobj.GetDetails();

            return Ok(list);
        }
          


        
    }
}
