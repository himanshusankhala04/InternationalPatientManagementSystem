using IpTreatmentOffering.Model;
using IpTreatmentOffering.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpTreatmentOffering.Controllers
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
        public IActionResult GetIPTreatmentPackages()
        {
            try
            {
                List<IPTreatmentPackage> list = _iPTreatmentPackageRepo.GetDetails();
                return Ok(list);
            }
            catch (Exception e)
            { return StatusCode(500); }
        }
        [HttpGet]
        [Route("api/[Controller]/[action]/{Name}")]
        public IActionResult GetTreatmentPackageByName(string Name)
        {
            try
            {
                List<IPTreatmentPackage> list = _iPTreatmentPackageRepo.GetDetails();
                var detail = list.FirstOrDefault(x => x.TreatmentPackageName == Name);
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
