using IPTreatmentOfferingService.Model;
using IPTreatmentOfferingService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentOfferingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class IPTreatmentController : ControllerBase
    {
        private readonly IIPTreatmentPackageRepo _iPTreatmentPackageRepo;
        public IPTreatmentController(IPTreatmentPackageRepo iPTreatmentPackageRepo)
        {
            _iPTreatmentPackageRepo = iPTreatmentPackageRepo;
        }

        [HttpGet]
        [Route("api/[Controller]/[action]")]
        public IActionResult IPTreatmentPackages()
        {
            try
            {
                List<IPTreatmentPackage> list = _iPTreatmentPackageRepo.GetDetails();
                return Ok(list);
            }
            catch (Exception e)
            { 
                return StatusCode(500); 
            }
        }
        [HttpGet]
        [Route("api/[Controller]/[action]/{Name}")]
        public IActionResult IPTreatmentPackageByName(string Name)
        {
            try
            {

                var detail = _iPTreatmentPackageRepo.GetDteailsByName(Name);
                if (detail != null)
                    return Ok(detail);
                else
                    return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
