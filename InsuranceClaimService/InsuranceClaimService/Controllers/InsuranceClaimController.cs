using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceClaimService.Model;
using InsuranceClaimService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceClaimService.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class InsuranceClaimController : Controller
    {
        private readonly IInsurerDetailsRepo _insuranceDetailsobj;

        public InsuranceClaimController(IInsurerDetailsRepo insuranceDetailsobj)
        {
            _insuranceDetailsobj = insuranceDetailsobj;
        }

        //get all the Insurer details
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllInsurerDetail()
        {
            try
            {
                List<InsurerDetail> list = _insuranceDetailsobj.GetDetails();
                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        //get the Insurer details by name
        [HttpGet("{insurerPackageName}")]
        [Route("[action]")]
        public IActionResult GetInsurerByPackageName(String insurerPackageName)
        {
            try
            {
                InsurerDetail insurer = _insuranceDetailsobj.GetInsurer(insurerPackageName);
                if(insurer == null)
                {
                    throw new Exception();
                }
                return Ok(insurer);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult InitiateClaim(InitiateClaim initiateClaim)
        {
            try
            {
                int balance = _insuranceDetailsobj.GetBalanceAmount(initiateClaim);
                
                return Ok(balance);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

    }
}
