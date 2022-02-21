using IPTreatmentOfferingService.Model;
using IPTreatmentOfferingService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IPTreatmentOfferingService.Model.IPTreatmentPackage;

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
        [Route("[action]")]
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
        [Route("[action]/{Name}")]
        [Authorize]
        public IActionResult IPTreatmentPackageByName(string name)
        {
            try
            {

                var detail = _iPTreatmentPackageRepo.GetDteailsByName(name);
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

        //added
        [HttpGet]
        [Route("[action]/{name}/{ailment}")]
        public IActionResult IPTreatmentPackageByNameAndAilment(string name, AilmentCategory ailment)
        {
            try
            {

                var detail = _iPTreatmentPackageRepo.GetDteailsByNameAndAilment(name, ailment);
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
