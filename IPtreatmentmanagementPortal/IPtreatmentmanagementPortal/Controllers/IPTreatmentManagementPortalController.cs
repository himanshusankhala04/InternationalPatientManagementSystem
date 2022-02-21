using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPtreatmentmanagementPortal.Model;
using IPtreatmentmanagementPortal.Models;
using IPtreatmentmanagementPortal.Repository;
using Microsoft.AspNetCore.Authorization;
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
            if (ViewBag != null)
            {
                ViewBag.msg = "<script> alert('Admin logged in successfully! '); </script>";
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult<List<InsurerDetails>>> GetInsuranceDetails()
        {
            try
            {
                var obj = _insuranceClaimRepo.GetAllInsurerDetails();
                if (obj != null)
                {
                    return View(await obj);
                }
                else
                {
                    ViewBag.msg = "Data not found!";
                    return View();
                }
            }
            catch
            {
                return BadRequest(500);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<SpecialistDetails>>> GetSpecialistDetails()
        {
            try
            {
                var obj = _treatmentOffering.GetAllSpecialistDetails();
                if (obj != null)
                {
                    return View(await obj);
                }
                else {
                    ViewBag.msg = "Data not found!";
                    return View();
                }
            }
            catch
            {
                return BadRequest(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<IPTreatmentPackage>>> GetTreatmentPackages()
        {
            try
            {
                var obj = _treatmentOffering.GetAllIPTreatmentPackages();
                if (obj != null)
                {
                    return View(await obj);
                }
                else {
                    ViewBag.msg = "Data not found!";
                    return View();
                }
            }
            catch
            {
                return BadRequest(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDetails>>> GetPatientDetails()
        {
            try
            {
                var obj = _treatment.GetAllPatientDetails();
                if (obj != null)
                {
                    return View(await obj);
                }
                else {
                    ViewBag.msg = "Data not found!";
                    return View();
                }
            }
            catch
            {
                return BadRequest(500);
            }
        }



        [HttpGet]
        public async Task<ActionResult<List<TreatmentPlan>>> GetTreatmentPlans()
        {
            try
            {
                var obj = _treatment.GetAllTreatmentDetails();
                if (obj != null)
                {
                    return View(await obj);
                }
                else {
                    ViewBag.msg = "Data not found!";
                    return View();
                }
            }
            catch
            {
                return BadRequest(500);
            }
        }

        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            ViewBag.Message = "Logged out!";
            return RedirectToAction("Login", "Login", new { area = "" });
        }

        [HttpGet]
        public IActionResult RegisterPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPatient(PatientDetails patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _treatment.FormulateTreatmentTimetable(patient);
                    return RedirectToAction("GetTreatmentStatus", "IPTreatmentManagementPortal", new { area = "" });
                }
                catch
                {
                    return BadRequest();
                }

            }
            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult GetTreatmentStatus()
        {
            try
            {
                var obj = _treatment.GetAllTreatmentStatus();
                if (obj != null)
                {
                    return View(obj);
                }
                else
                {
                    ViewBag.msg = "Data not found!";
                    return View();
                }
            }
            catch
            {
                return BadRequest(500);
            }
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult InitiateClaim(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("[action]/{id}/{InsuranceProvider}")]
        public IActionResult InitiateClaim(int id, string InsuranceProvider)
        {
            try
            {
                int balance = _insuranceClaimRepo.GetBalanceAmmount(id, InsuranceProvider);
                _treatment.UpdateTreatmentStatus(id, balance);
                return RedirectToAction("GetTreatmentStatus", "IPTreatmentManagementPortal", new { area = "" });
            }
            catch 
            {
                return BadRequest(500);
            }
        }
    }
}
