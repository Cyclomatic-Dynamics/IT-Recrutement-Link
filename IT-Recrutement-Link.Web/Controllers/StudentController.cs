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
        //
        // GET: /Student/
        public ActionResult AddStudent()
        {
            return View("AddStudentForm");
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