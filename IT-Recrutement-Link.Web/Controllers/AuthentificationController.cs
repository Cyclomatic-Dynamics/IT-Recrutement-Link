using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IT_Recrutement_Link.Web.Models;
using System.ComponentModel.DataAnnotations;

    
namespace IT_Recrutement_Link.Web.Controllers
{
    public class AuthentificationController : Controller
    {
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
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, model.RememberMe);
                }

                ModelState.AddModelError("", "Incorrect username and/or password");
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