using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using IPtreatmentmanagementPortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPtreatmentmanagementPortal.Controllers
{
    public class IPTreatmentManagementPortalController : Controller
    {
        private readonly IInsuranceClaimRepo _insuranceClaimRepo;
        private readonly IIPTreatmentOfferingRepo _treatmentOffering;
        private readonly IIPTreatmentRepo _treatment;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public IPTreatmentManagementPortalController(IHttpContextAccessor httpContextAccessor, IInsuranceClaimRepo insuranceClaimRepo, IIPTreatmentOfferingRepo treatmentOffering, IIPTreatmentRepo treatment)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;

            _insuranceClaimRepo = insuranceClaimRepo;
            _treatmentOffering = treatmentOffering;
            _treatment = treatment;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<List<InsurerDetails>>> GetInsuranceDetails()
        {
            
            var obj = _insuranceClaimRepo.GetAllInsurerDetails();
            if(obj != null)
            {
                return View(await obj);
            }
            else {
                ViewBag.msg = "Data not found!";
                return View();
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<SpecialistDetails>>> GetSpecialistDetails()
        {
            var obj = _treatmentOffering.GetAllSpecialistDetails();
            if(obj != null)
            {
                return View(await obj);
            }
            else {
                ViewBag.msg = "Data not found!";
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<IPTreatmentPackage>>> GetTreatmentPackages()
        {
            var obj = _treatmentOffering.GetAllIPTreatmentPackages();
            if(obj != null)
            {
                return View(await obj);
            }
            else {
                ViewBag.msg = "Data not found!";
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDetails>>> GetPatientDetails()
        {
            var obj =  _treatment.GetAllPatientDetails();
            if(obj != null)
            {
                return View(await obj);
            }
            else {
                ViewBag.msg = "Data not found!";
                return View();
            }
        }

       

        [HttpGet]
        public async Task<ActionResult<List<TreatmentPlan>>> GetTreatmentPlans()
        {
            var obj =  _treatment.GetAllTreatmentDetails();
            if(obj != null)
            {
                return View(await obj);
            }
            else {
                ViewBag.msg = "Data not found!";
                return View();
            }
        }

    }
}
