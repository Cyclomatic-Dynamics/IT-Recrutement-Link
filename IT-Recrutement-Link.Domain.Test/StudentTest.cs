using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT_Recrutement_Link.Domain.Entities;
namespace IT_Recrutement_Link.Domain.Test
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void shouldRegisterInAJobPropsition()
        {
            Job job = new Job(null, "Cyclomatic Dynamics");
            Student student = new Student("Bob");
            student.Apply(job);
            Assert.IsTrue(job.registeredStudents.Contains(student));
        }
    }
}
