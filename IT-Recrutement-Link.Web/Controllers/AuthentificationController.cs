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
        [AllowAnonymous]
        public ActionResult Login(Login model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NameValueCollection nvc = Request.Form;
                    Company company = companyService.LoginCompany(nvc["login"], nvc["password"]);
                    HttpCookie myCookie = new HttpCookie("myCookie"); 
                    myCookie.Values.Add("id", company.Id.ToString());
                    myCookie.Expires = DateTime.Now.AddDays(12);
                    Response.Cookies.Add(myCookie);
                    return View("DisplayCompany");
                }
                catch (WrongPasswordException e)
                {
                    ViewBag.WrongPasswordMessage = "Wrong Password";
                    return View(model);                
                }
            }
            else
            {
                return View(model);
            }
            
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}