using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Recrutement_Link.Web;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Domain;


namespace IT_Recrutement_Link.Web.Controllers
{
    public class StudentController : Controller
    {
        private StudentService studentService;
        public StudentController(StudentService sService)
        {
            studentService = sService;
        }
        [HttpGet]
        public ActionResult ViewStudent(Student student){
            return View(student);
        }
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            return View();
        }
	}
}