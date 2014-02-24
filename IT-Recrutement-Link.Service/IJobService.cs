using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Recrutement_Link.Domain.Entities;


namespace IT_Recrutement_Link.Service
{
    public interface IJobService
    {
        Job ViewJob(int id);
        IList<Job> ViewJobs(string word);
        IList<Job> ViewOwnJobs(Company company);

    }
}
