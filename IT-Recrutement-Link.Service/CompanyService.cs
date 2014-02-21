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
        private IBlobStorage blobStorage;
        private IUnitOfWork unitOfWork;
        public CompanyService(IBlobStorage storage, IUnitOfWork unitOfWork)
        {
            blobStorage = storage;
            this.unitOfWork = unitOfWork;

        }
        public void AddCompany(Company company, string password, FileStream video,
            FileStream image, FileStream slide)
        {
            company.PasswordHash = Hash(password);
            company.VideoUrl = blobStorage.upLoad(video);
            company.LogoPictureUrl = blobStorage.upLoad(image);
            company.SlidesUrl = blobStorage.upLoad(slide);
            unitOfWork.Add<Company>(company);
            unitOfWork.Commit();
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
