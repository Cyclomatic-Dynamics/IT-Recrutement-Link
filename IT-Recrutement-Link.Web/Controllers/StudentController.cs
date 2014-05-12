using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;
using IT_Recrutement_Link.Web;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Entities;


namespace IT_Recrutement_Link.Web.Controllers
{
    public class StudentController : Controller
    {
        //private readonly JobService jobService;
        private StudentService studentService;
        public StudentController(StudentService sService)
        {
            studentService = sService;
            //this.jobService = jobService;
        }
        //
        // GET: /Student/
        public ActionResult AddStudent()
        {
            return View("AddStudentForm");
        }
        /*[HttpPost]
        public ActionResult SearchJob(string searchString)
        {
            var jobs = jobService.ViewJobs(searchString);
            return View(jobs);
        }*/
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                //
               // string url = CloudBlobStorage.upload(HttpFileStream);
                // student.Videourl = url;
                //service.Add(student, password);
                return View(student);
            }
            else {
                return View(student);
            }
        }
        public ActionResult DisplayStudentProfil()
        {
            int studentId = Convert.ToInt32(((string)Session["id"]));
            Student student = studentService.ViewStudent(studentId);
            ViewBag.Name = student.Name;
            return View();
        }


        
	}
}