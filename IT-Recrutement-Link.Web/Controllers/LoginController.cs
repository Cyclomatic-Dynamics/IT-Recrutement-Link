using IT_Recrutement_Link.Domain.Domain;
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
    public class LoginController : Controller
    {
        private LoginService loginService;
        public LoginController(LoginService lService)
        {
            loginService = lService;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   User user = loginService.LoginUser(login.Email, login.Password);
             
                       Student student = (Student)user;
                       return View("ViewStudent", "Student", student);
                   
                   
                }
                catch (WrongCredentialException)
                {
                    return View(login);
                }
            }
            else
            {
                return View(login);
            }  
        }
    }
}