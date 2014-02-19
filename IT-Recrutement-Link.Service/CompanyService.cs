using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IT_Recrutement_Link.Domain.Entities;
namespace IT_Recrutement_Link.Service
{
    public class CompanyService
    {
        public CompanyService(IBlobStorage storage, IUnitOfWork unitOfWork)
        {

        }
        public void AddCompany(string name, FileStream video, FileStream image, 
            FileStream slide, ActivitySectorEnum activitySector, string address, CompanySizeEnum size,
            DateTime creationDate, bool spontanousApplication, IList<string> keywords)
        {

        }
                
    }
}
