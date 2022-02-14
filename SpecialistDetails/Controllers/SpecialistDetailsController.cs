using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpTreatmentOffering.Model;
using IpTreatmentOffering.Repository;

namespace IpTreatmentOffering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistDetailsController : ControllerBase
    {
        private readonly ISpecialistDetailsRepo _specialistDetailsobj;
        
        public SpecialistDetailsController(SpecialistDetailsRepo specialistDetailsobj)
        {
            _specialistDetailsobj = specialistDetailsobj;
            
        }
        [HttpGet]
        public IActionResult GetAllSpecialistDetails()
        {
            try
            {
                List<SpecialistDetails> list = _specialistDetailsobj.GetDetails();
                return Ok(list);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
       

    }
}
