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
        public StudentService(IUnitOfWork storage, IBlobStorage unitOfWork)
        {

        }
        public void AddStudent(string name, string Lastname, FileStream video, FileStream image,
            FileStream slide, IList<string> keywords, DateTime dateNaissance,
            List<string> university, List<string> diplome, List<string> formation,
            List<string> experience, CompetenceSectorEnum competenceSectorName)
        {

        }
    }
}
