using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPTreatmentService.Model;
using IPTreatmentService.Repository;

namespace IPTreatmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : Controller
    {

        private readonly ITreatmentPlanRepo _treatmentobj;
        public TreatmentController(ITreatmentPlanRepo treatmentobj)
        {
            _treatmentobj = treatmentobj;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTreatmentDetails()
        {

            List<TreatmentPlan> list = _treatmentobj.GetDetails();

            return Ok(list);


        }

        [HttpPost]
        [Route("api/[Controller]/[action]")]
        public IActionResult FormulateTreatmentTimetable(PatientDetail patient)
        {
            try
            {
                var obj = _treatmentobj.GetTreatmentPlan(patient);

                return Ok(obj);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

    }
}
