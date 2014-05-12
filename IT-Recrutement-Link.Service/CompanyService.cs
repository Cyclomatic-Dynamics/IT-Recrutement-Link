using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IT_Recrutement_Link.Domain.Domain;

namespace IT_Recrutement_Link.Service
{
    public class CompanyService
    {
        private IUnitOfWork unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddCompany(Company company)
        {
            unitOfWork.Add<Company>(company);
            unitOfWork.Commit();
        }
        public void ModifyCompany(Company company)
        {
            unitOfWork.Update<Company>(company);
            unitOfWork.Commit();
        }
        public void RemoveCompany(Company company)
        {
            unitOfWork.Remove<Company>(company);
            unitOfWork.Commit();
        }
        public Company ViewCompany(int id)
        {
                return unitOfWork.FindById<Company>(id);
        }
        public IList<Company> ViewAllCompanies()
        {
            return unitOfWork.FindMany<Company>(c => true);
        }
        
        public void AddJob(string jobname, Company company)
        {
            Job job = company.CreateJob(jobname);
            unitOfWork.Add<Job>(job);
            unitOfWork.Commit();
        }
        public void ModifyJob(Job job)
        {
            unitOfWork.Update<Job>(job);
            unitOfWork.Commit();
        }
        public void RemoveJob(Job job)
        {
            unitOfWork.Remove<Job>(job);
            unitOfWork.Commit();
        }
    }
}
