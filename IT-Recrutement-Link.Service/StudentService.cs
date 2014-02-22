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
        private IBlobStorage blobStorage;
        private IUnitOfWork unitOfWork;
        public StudentService(IBlobStorage storage, IUnitOfWork unit)
        {
            blobStorage = storage;
            unitOfWork = unit;
        }
        public void AddStudent(Student student, FileStream video, FileStream image,
            FileStream slide)
        {
            student.VideoUrl = blobStorage.upLoad(video);
            student.ProfilePictureUrl = blobStorage.upLoad(image);
            student.SlidesUrl = blobStorage.upLoad(slide);
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
                throw new EntityNotFoundException<Company>(id);
            }
        }
        public void ModifyStudent(Student student)
        {
            unitOfWork.Update<Student>(student);
            unitOfWork.Commit();
        }
        public void ApplyJob(Job job, Student student)
        {
            student.Apply(job);
            unitOfWork.Update<Job>(job);
            unitOfWork.Commit();
        }
    }
}