using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Recrutement_Link.Web;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Entities;

namespace IT_Recrutement_Link.Web.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyService companyService;
        public CompanyController(CompanyService service)
        {
            companyService = service;
        }
        private readonly JobService jobService;
        [HttpGet]
        public ActionResult AddCompanyForm()
        {
            
            
            return View(new Company());
        }
        [HttpPost]
        public ActionResult AddCompanyForm(Company company)
        {
            if (!ModelState.IsValid)
            {
                
                return View(company);
            }
            return RedirectToAction("DisplayCompanyProfil");
        }
        
        //[HttpPost]
        /*
        public ActionResult AddCompanyForm()
        {
            ViewBag.Message = "The category doesn't exist";
            return View();
        }
        */
        public ActionResult EditCompanyProfil()
        {
            return View();
        }
        public ActionResult DisplayCompanyProfil()
        {
            int companyId = Convert.ToInt32(((string)Session["id"]));
            Company company = companyService.ViewCompany(companyId);
            ViewBag.Name = company.Name;
            return View();
        }
        public ActionResult SearchJob(Company company)
        {
            var jobs = jobService.ViewOwnJobs(company);
            return View(jobs);
        }
        public ActionResult AddJob()
        {

        }
        public static string id { get; set; }

        public static string passwordhash { get; set; }
    }




}

