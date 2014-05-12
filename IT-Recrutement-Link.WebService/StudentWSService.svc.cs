using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Domain;
using IT_Recrutement_Link.DataAccess;
namespace IT_Recrutement_Link.WebService
{
    public class StudentWSService : IStudentWSService
    {
        private StudentService studentService;
        public StudentWSService()
        {
            studentService = new StudentService(new Context());
        }
        public List<StudentWS> GetAllStudents()
        {
            //StudentService studentService = new StudentService(new Context());
            IList<Student> allStudents = studentService.ViewAllStudents();
            return convertDomainToDataContractMany(allStudents);
        }
        private List<StudentWS> convertDomainToDataContractMany(IList<Student> students)
        {
            List<StudentWS> studentsWS = new List<StudentWS>();
            foreach (Student student in students)
            {
                studentsWS.Add(convertDomainToDataContractOne(student));
            }
            return studentsWS;
        }
        private StudentWS convertDomainToDataContractOne(Student student)
        {
            return new StudentWS
            {
                Id = student.Id,
                Email = student.Email,
                BirthDate = student.BirthDate,
                Name = student.Name,
                LastName = student.LastName,
                Diplomas = student.Diplomas,
                Experiences = student.Experiences,

            };
        }
        public StudentWS GetStudent(string id)
        {
            int intId = Convert.ToInt32(id);
            //StudentService studentService = new StudentService(new Context());
            Student st = studentService.ViewStudent(intId);
            return convertDomainToDataContractOne(st);
        }
        public void NewStudent(StudentWS student)
        {
            //StudentService studentService = new StudentService(new Context());
            Student student1 = new Student(student.Id, student.Name, student.Email, student.LastName, student.BirthDate, student.Diplomas, student.Experiences);
            studentService.AddStudent(student1);
        }
        public void UpdateStudent(StudentWS student)
        {
            //StudentService studentService = new StudentService(new Context());
            Student student1 = new Student(student.Id, student.Name, student.Email, student.LastName, student.BirthDate, student.Diplomas, student.Experiences);
            studentService.ModifyStudent(student1);
        }
        public void DeleteStudent(string id)
        {
            int intId = Convert.ToInt32(id);
           // StudentService studentService = new StudentService(new Context());
            studentService.RemoveStudent(studentService.ViewStudent(intId));
        }

    }
}
