using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IT_Recrutement_Link.Domain.Entities;


namespace IT_Recrutement_Link.Service
{
    public class JobService
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
                throw new EntityNotFoundException<Company>(id);
            }
        }
        
        
    }
}
