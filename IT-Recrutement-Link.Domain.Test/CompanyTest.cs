using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT_Recrutement_Link.Domain.Entities;
namespace IT_Recrutement_Link.Domain.Test
{
    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void shouldCreateAJob()
        {
            Company company = new Company("Cyclomatic Dynamics");
            string jobName = "Cloud Manager";
            Job job = company.CreateJob(jobName);
            Assert.AreEqual(jobName, job.Name);
        }
    }
}
