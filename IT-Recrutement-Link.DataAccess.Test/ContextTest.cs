using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT_Recrutement_Link.Domain.Entities;
using System.Collections.Generic;

namespace IT_Recrutement_Link.DataAccess.Test
{
    [TestClass]
    public class ContextTest
    {
       /* private Context context = new Context();

        [TestMethod]
        public void ShouldAddEntity()
        {
            Student student = LegalEntityFactory.CreateStudent("Bob", "Orton");
            context.Add<Student>(student);
            context.Commit();
            Assert.AreEqual("Bob", context.FindById<Student>(1).Name);
            Assert.AreEqual("Orton", context.FindById<Student>(1).LastName);
        }

        [TestMethod]
        public void ShouldRemoveEntity()
        {
            Company company = LegalEntityFactory.CreateCompany("Capcom");
            context.Add<Company>(company);
            context.Commit();
            context.Remove<Company>(company);
            context.Commit();
            Assert.AreEqual(null, context.FindById<Company>(company.Id));
        }

        [TestMethod]
        public void ShouldFindEntityWithAnExpression()
        {
            Company company = LegalEntityFactory.CreateCompany("Capcom"); 
            Student student = LegalEntityFactory.
                CreateStudent("Chedy", "Kablam");
            Job job = company.CreateJob("PoliceMan");
            context.Add<Job>(job);
            context.Commit();
            Assert.IsTrue(context.FindMany<Job>(j => j.Name.Equals("PoliceMan"))
                .Contains(job));
        }
        [TestMethod]
        public void ShouldUpdateEntity()
        {
            Company company = LegalEntityFactory.CreateCompany("Cyclomatic Dynamics");
            context.Add<Company>(company);
            context.Commit();
            company.Name = "Bethesda";
            context.Update<Company>(company);
            context.Commit();
            Assert.IsTrue(context.FindMany<Company>(
                c => c.Name.Equals("Bethesda")).Count == 1);
        }
        
        
    }
    
    static class LegalEntityFactory
    {
       /* public static Student CreateStudent(string name, string lastName)
        {
            return new Student { 
                   Name = name,
                   LastName = lastName,
                   CompetenceSectorName = CompetenceSectorEnum.Design,
                   DateNaissance = new DateTime(2000, 10, 10),
                   Email = "mail@mail.com",
                   Experience = new List<string>(),
                   Formation = new List<string>(),
                   Keywords = new List<string>(),
                   PasswordHash = "dsffbtghsd",
                   ProfilePictureUrl = "url",
                   SlidesUrl = "url",
                   University = new List<string>(),
                   VideoUrl = "url",
                   Diplome = new List<string>()
            };
        }
        public static Company CreateCompany(string name)
        {
            return new Company
            {
                Name = name,
                PasswordHash = "aaaa",
                AcceptSpontanousApplication = true,
                ActivitySectorName = ActivitySectorEnum.Agriculture,
                Address = "36 Terry St",
                CompanySize = CompanySizeEnum.small,
                CreationDate = new DateTime(2000, 10, 10),
                Email = "aaaaaaa",
                Keywords = new List<string>(),
                LogoPictureUrl = "url",
                SlidesUrl = "azerty",
                VideoUrl = "video"
            }; 
        }
        */
    }
}
