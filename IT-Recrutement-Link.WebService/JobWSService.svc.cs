using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Domain;
using IT_Recrutement_Link.DataAccess;


namespace IT_Recrutement_Link.WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "JobWSService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez JobWSService.svc ou JobWSService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class JobWSService : IJobWSService
    {
        public List<JobWS> GetAllJobs()
        {
            JobService service = new JobService(new Context());
            IList<Job> jobs = service.ViewJobs();
            return convertDomainToDataContractMany(jobs);
        }
        private List<JobWS> convertDomainToDataContractMany(IList<Job> jobs)
        {
            List<JobWS> jobsWS = new List<JobWS>();
            foreach (Job job in jobs)
            {
                jobsWS.Add(convertDomainToDataContractOne(job));
            }
            return jobsWS;
        }
        private JobWS convertDomainToDataContractOne(Job job)
        {
            return new JobWS
            {
                Id = job.Id,
                Name = job.Name,
                
            };
        }
        public JobWS GetJob(int id)
        {
            JobService service = new JobService(new Context());
            Job jb = service.ViewJob(id);
            return convertDomainToDataContractOne(jb);
        }
        public void NewJob(JobWS job)
        {
            JobService service = new JobService(new Context());
            Job job1 = new Job(job.company,job.Name);
            service.AddJob(job1);
        }
        public void UpdateJob(JobWS job)
        {
            JobService service = new JobService(new Context());
            Job job1 = new Job(job.company,job.Name);
            service.UpdateJob(job1);
        }
        public void DeleteJob(JobWS job)
        {
            JobService service = new JobService(new Context());
            Job job1 = new Job(job.company,job.Name);
            service.RemoveJob(job1);
        }
        public List<JobWS> GetOwnJob(CompanyWS cp)
        {
            JobService service = new JobService(new Context());
            Company company1 = new Company(cp.Id, cp.Email, cp.Name, cp.URL, cp.Address, cp.ActivitySectorName, cp.Country);
            IList<Job> jobs = service.ViewOwnJobs(company1);
            return convertDomainToDataContractMany(jobs);
        }


    }
    
}
