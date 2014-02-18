using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT_Recrutement_Link.Domain.Entities;
namespace IT_Recrutement_Link.Domain.Test
{
    [TestClass]
    public class JobTest
    {
        [TestMethod]
        public void shouldRegisterStudent()
        {
            Student bob = new Student("Bob");
            Job job = new Job(null, "A job");
            job.Register(bob);
            Assert.IsTrue(job.registeredStudents.Contains(bob));
        }
    }
}
