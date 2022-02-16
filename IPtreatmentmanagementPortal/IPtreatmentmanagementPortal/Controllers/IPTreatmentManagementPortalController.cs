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
        private readonly IIPTreatmentOffering _treatmentOffering;
        private readonly IIPTreatment _treatment;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public IPTreatmentManagementPortalController(IHttpContextAccessor httpContextAccessor, IInsuranceClaimRepo insuranceClaimRepo, IIPTreatmentOffering treatmentOffering, IIPTreatment treatment)
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
        public ActionResult<List<InsurerDetails>> GetInsuranceDetails()
        {
            
            //var obj = _insuranceClaimRepo.GetAllInsurerDetails();
            //if(obj != null)
            //{
            //    return View(obj);
            //}
            //else {
                ViewBag.msg = "Data not found!";
                return View();
            //}
        }


        [HttpGet]
        public async Task<ActionResult<List<SpecialistDetails>>> GetSpecialistDetails()
        {
            //return  View(await _treatmentOffering.GetAllSpecialistDetails());
            //if(obj != null)
            //{
            //    return View(obj);
            //}
            //else {
            ViewBag.msg = "Data not found!";
            return View();
            //}
        }

        [HttpGet]
        public ActionResult<List<IPTreatmentPackage>> GetTreatmentPackages()
        {
            //return View(_treatmentOffering.GetAllIPTreatmentPackages());
            //if(obj != null)
            //{
            //    return View(obj);
            //}
            //else {
            ViewBag.msg = "Data not found!";
            return View();
            //}
        }

        [HttpGet]
        public ActionResult<List<PatientDetails>> GetPatientDetails()
        {
            //return View(_treatment.GetAllPatientDetails());
            //if(obj != null)
            //{
            //    return View(obj);
            //}
            //else {
            ViewBag.msg = "Data not found!";
            return View();
            //}
        }

        [HttpGet]
        public ActionResult<List<TreatmentPlan>> GetTreatmentPlans()
        {
            //return View(_treatment.GetAllTreatmentDetails());
            //if(obj != null)
            //{
            //    return View(obj);
            //}
            //else {
            ViewBag.msg = "Data not found!";
            return View();
            //}
        }

    }
}
