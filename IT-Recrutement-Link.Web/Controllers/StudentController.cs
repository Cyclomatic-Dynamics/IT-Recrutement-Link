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
    public class StudentController : Controller
    {
        private readonly IJobService jobService;
        public StudentController(IJobService jobService)
        {
            this.jobService= jobService;
        }
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddStudentForm()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult AddStudentForm(Student student)
        {
            if (!ModelState.IsValid)
            {

                return View(student);
            }
            return RedirectToAction("DisplayStudentProfil");
        }
        public ActionResult EditStudentProfil()
        {

            return View();
        }
        public ActionResult DisplayStudentProfil()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SearchJob(string searchString)
        {
            var jobs = jobService.ViewJobs(searchString);
            return View(jobs);
        }
	}
}