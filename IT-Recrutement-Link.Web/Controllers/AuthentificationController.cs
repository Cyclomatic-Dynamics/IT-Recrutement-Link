using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IT_Recrutement_Link.Web.Models;
using System.ComponentModel.DataAnnotations;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Entities;

    
namespace IT_Recrutement_Link.Web.Controllers
{
    public class AuthentificationController : Controller
    {
        private CompanyService companyService;
        private StudentService studentService;
        public AuthentificationController(CompanyService cService, StudentService sService)
        {

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
                /*if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, model.RememberMe);
                }
                
                ModelState.AddModelError("", "Incorrect username and/or password");*/
                CompanyService service = new CompanyService(null, null);
                Company c = service.Login(email, password);
                HttpCookie myCookie = new HttpCookie("myCookie");

                //Add key-values in the cookie
                myCookie.Values.Add("id", c.Id);
                
                //set cookie expiry date-time. Made it to last for next 12 hours.
                myCookie.Expires = DateTime.Now.AddDays(12);

                //Most important, write the cookie to client.
                Response.Cookies.Add(myCookie);



            }

            return View(model);
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