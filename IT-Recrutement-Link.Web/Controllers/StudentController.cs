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
        private readonly JobService jobService;
        public StudentController(JobService jobService)
        {
            this.jobService = jobService;
        }
        //
        // GET: /Student/
        public ActionResult AddStudent()
        {
            return View("AddStudentForm");
        }
        [HttpPost]
        public ActionResult SearchJob(string searchString)
        {
            var jobs = jobService.ViewJobs(searchString);
            return View(jobs);
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                //
                string url = CloudBlobStorage.ipload(HttpFileStream)
                // student.Videourl = url;
                //service.Add(student, password);
                //return RedirectToAction(viewaction)
            }
            else {
                return View(Model);
            }
        }


        
	}
}