using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IT_Recrutement_Link.Domain.Entities;


namespace IT_Recrutement_Link.Service
{
    public class JobService : IJobService
    {
        private IUnitOfWork unitOfWork;
        public JobService(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }
        
        public Job ViewJob(int id)
        {
            try
            {
            return unitOfWork.FindById<Job>(id);
            }
            catch (Exception)
            {
                throw new EntityNotFoundException<Job>(id);
            }
        }
<<<<<<< HEAD
        public IList<Job> ViewJobs(string word)
        {
            
                return unitOfWork.FindMany<Job>(j=>j.Name.Equals(word));
            
        }
        public IList<Job> ViewOwnJobs(Company company1)
        {

            return unitOfWork.FindMany<Job>(j => j.company.Equals(company1));

=======

        public void RemoveJob(int id)
        {
            RemoveJob(unitOfWork.FindById<Job>(id));
        }
        public void RemoveJob(Job job)
        {
            unitOfWork.Remove<Job>(job);
            unitOfWork.Commit();
>>>>>>> be240b5870e585e867674330b100825fe55951be
        }
        
    }
}
