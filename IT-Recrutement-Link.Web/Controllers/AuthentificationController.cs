using IT_Recrutement_Link.Domain.Entities;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
    
namespace IT_Recrutement_Link.Web.Controllers
{
    public class AuthentificationController : Controller
    {
        private CompanyService companyService;
        private StudentService studentService;
        public AuthentificationController(CompanyService cService, StudentService sService)
        {
            companyService = cService;
            studentService = sService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
       // [AllowAnonymous]
        public ActionResult Login(Login model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                NameValueCollection nvc = Request.Form;
                try
                {
                    if (nvc["ChosenChoice"].Equals("Student"))
                    {
                        loginStudent(nvc);
                        return View("DisplayStudent");
                    }
                    else
                    {
                        loginCompany(nvc);
                        return RedirectToAction("DisplayCompanyProfil", "Company");/*View("DisplayCompanyProfil", "Company");*/
                    }
                }

                catch (WrongCredentialException)
                {
                    ViewBag.WrongPasswordMessage = "Wrong Password!!!!!!!";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        private void loginStudent(NameValueCollection nvc)
        {
            Student student = studentService.LoginStudent(nvc["UserName"], nvc["Password"]);
           retainSessionState(student.Id.ToString());
        }
        private void loginCompany(NameValueCollection nvc)
        {
            Company company = companyService.LoginCompany(nvc["UserName"], nvc["Password"]);
            retainSessionState(company.Id.ToString());
        }
        private void retainSessionState(string id)
        {
            Session["id"] = id;
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
    public class TestController
    {
        public ActionResult SelectChoice()
        {
            return SelectChoice();
        }
    }
}