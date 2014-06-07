using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IT_Recrutement_Link.Domain.Entities;

namespace IT_Recrutement_Link.Service
{
    public class StudentService
    {
        private IUnitOfWork unitOfWork;
        public StudentService(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }
        public void AddStudent(Student student, string password)
        { 
            student.PasswordHash = HashUtil.SHA1Hash(password);
            unitOfWork.Add<Student>(student);
            unitOfWork.Commit();
        }
        public Student ViewStudent(int id)
        {
            try
            {
                return unitOfWork.FindById<Student>(id);
            }
            catch (Exception)
            {
                throw new EntityNotFoundException<Student>(id);
            }
        }
        public Student ListStudent(int id)
        {
            try
            {
                return unitOfWork.FindMany<Student>();
            }
            catch (Exception)
            {
                throw new EntityNotFoundException<Student>(id);
            }
        }
        public void ModifyStudent(Student student)
        {
            unitOfWork.Update<Student>(student);
            unitOfWork.Commit();
        }
        public void ApplyStudentToJob(Student student, Job job)
        {
            student.Apply(job);
            unitOfWork.Update<Job>(job);
            unitOfWork.Commit();
        }
        public Student LoginStudent(string email, string password)
        {
            Student student = unitOfWork.FindMany<Student>(s => (s.Email.Equals(email))).
                FirstOrDefault<Student>();
            if (student != null)
            {
                if (HashUtil.SHA1Hash(password).Equals(student.PasswordHash))
                {
                    return student;
                }
                else
                {
                    throw new WrongCredentialException();
                }
            }
            else
            {
                throw new WrongCredentialException();
            }
        }
        
    }
}