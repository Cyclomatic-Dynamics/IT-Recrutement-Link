using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
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
            company.PasswordHash = Hash(password);
            unitOfWork.Add<Company>(company);
            unitOfWork.Commit();
        }
        public void UpdateCompany(Company company)
        {
            unitOfWork.Update<Company>(company);
            unitOfWork.Commit();
        }
        public Company LoginCompany(string email, string password)
        {
            Company company = unitOfWork.FindOne<Company>(email);
            if (Hash(password).Equals(company.PasswordHash))
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
        private string Hash(string input)
        {
            using (SHA1Managed hasher = new SHA1Managed())
            {
                
                byte[] textData = Encoding.UTF8.GetBytes(input);
                byte[] hash = hasher.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty).ToLower();
            }
        }
    }
}
