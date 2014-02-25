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
        
        [HttpGet]
        public ActionResult AddCompanyForm()
        {
            
            
            return View(new Company()/*"AddCompanyForm"*/);
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
        public ActionResult AddCompanyForm()gh
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
            //var Company = CompanySevice.getCompany(Id);
            return View();
        }


        public static string id { get; set; }

        public static string passwordhash { get; set; }
    }




}

