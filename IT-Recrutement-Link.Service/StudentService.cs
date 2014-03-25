using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IT_Recrutement_Link.Domain.Domain;

namespace IT_Recrutement_Link.Service
{
    public class StudentService
    {
        private IUnitOfWork unitOfWork;
        public StudentService(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }
        public void AddStudent(Student student)
        { 
            unitOfWork.Add<Student>(student);
            unitOfWork.Commit();
        }
        public Student ViewStudent(int id)
        {
                return unitOfWork.FindById<Student>(id); 
        }
        public void ModifyStudent(Student student)
        {
            unitOfWork.Update<Student>(student);
            unitOfWork.Commit();
        }
    }
}