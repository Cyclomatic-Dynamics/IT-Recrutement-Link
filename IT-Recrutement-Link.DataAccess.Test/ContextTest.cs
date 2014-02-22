using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT_Recrutement_Link.Domain.Entities;


namespace IT_Recrutement_Link.DataAccess.Test
{
    [TestClass]
    public class ContextTest
    {
        private Context context = new Context();
       
        [TestMethod]
        public void ShouldAddEntity()
        {
            Student student = new Student
            {
            Name = "Bob",
            LastName = "Orton",
            
            };
            student.LastName = "Kablam";
            context.Add<Student>(student);
            context.Commit();
            Assert.AreEqual("blob", context.FindById<Student>(1).Name);
        }
        
        [TestMethod]
        public void ShouldRemoveEntity()
        {
            Company company = new Company("Capcom");
            context.Add<Company>(company);
            context.Commit();
            context.Remove<Company>(company);
            context.Commit();
            Assert.AreEqual(0, context.FindAll<Company>().Count);
        }
        [TestMethod]
        public void ShouldFindEntityWithAnExpression()
        {
            Company company = new Company("Capcom");
            Student student = new Student("Chedy");
            student.LastName = "Kablam";
            Job job = company.CreateJob("PoliceMan");
            context.Add<Job>(job);
            context.Commit();
            Assert.IsTrue(context.FindMany<Job>(j => j.Name.Equals("PoliceMan"))
                .Contains(job));
        }
        [TestMethod]
        public void ShouldUpdateEntity()
        {
            Company company = new Company{Name = "Cyclomatic Dynamics"};
            context.Add<Company>(company);
            context.Commit();
            company.Name = "Bethesda";
            context.Update<Company>(company);
            context.Commit();
            Assert.IsTrue(context.FindMany<Company>(
                c => c.Name.Equals("Bethesda")).Count == 1);
        }
    }
}
