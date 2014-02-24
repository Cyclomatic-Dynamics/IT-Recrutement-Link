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
        private IUnitOfWork unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddCompany(Company company, string password)
        {
            company.PasswordHash = HashUtil.SHA1Hash(password);
            unitOfWork.Add<Company>(company);
            unitOfWork.Commit();
        }
        public void ModifyCompany(Company company)
        {
            unitOfWork.Update<Company>(company);
            unitOfWork.Commit();
        }
        public Company LoginCompany(string email, string password)
        {
            Company company = unitOfWork.FindMany<Company>(c => (c.Email.Equals(email))).
                FirstOrDefault<Company>();
            if (HashUtil.SHA1Hash(password).Equals(company.PasswordHash))
            {
                return company;
            }
            else {
                throw new WrongPasswordException();
            }
        }
        public Company ViewCompany(int id)
        {
            try
            {
                return unitOfWork.FindById<Company>(id);
            }
            catch (Exception)
            {
                throw new EntityNotFoundException<Company>(id);
            }
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
