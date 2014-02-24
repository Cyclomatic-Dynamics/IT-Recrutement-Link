using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using IT_Recrutement_Link.Domain.Entities;
using Moq;
namespace IT_Recrutement_Link.Service.Test
{
    [TestClass]
    public class CompanyServiceTest
    {
        private static IList<string> keywords = new List<string>(
            new string[] { "CS", "IT" });

        private Company company;
        private Mock<IUnitOfWork> unitOfWork;
        private CompanyService service;
        [TestInitialize]
        public void SetUp()
        {
            company = new Company
        {
            Name = "Hp",
            Email = "hp@hp.com",
            Keywords = keywords,
            CreationDate = new DateTime(1980, 10, 10),
            ActivitySectorName = ActivitySectorEnum.Software_engeneering,
            Address = "36 Terry Street",
            CompanySize = CompanySizeEnum.small,
            AcceptSpontanousApplication = false
        };
            unitOfWork = new Mock<IUnitOfWork>();
            service = new CompanyService(unitOfWork.Object);
        }
        [TestMethod]
        public void shouldAddCompany()
        {
            Company newCompany = company;
            string password = "Password2149";

            service.AddCompany(newCompany, password);

            Assert.AreNotEqual(password, newCompany.PasswordHash);
            unitOfWork.Verify(unit => unit.Add<Company>(newCompany), Times.Once());
            unitOfWork.Verify(unit => unit.Commit(), Times.Once());
        }
        [TestMethod]
        public void shouldUpdateCompany()
        {
            Company updatedCompany = company;
            service.ModifyCompany(company);
            unitOfWork.Verify(unit => unit.Update<Company>(updatedCompany), Times.Once());
            unitOfWork.Verify(unit => unit.Commit(), Times.Once());
        }
        [TestMethod]
        public void shouldLoginCompany()
        {
            /*company.PasswordHash = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8";
            Company loginCompany = company;
            string email = company.Email;
            string password = "password";
            unitOfWork.Setup<Company>(unit => unit.FindById<Company>(
                email)).Returns(loginCompany);
            Company returnedCompany = service.LoginCompany(email, password);
            unitOfWork.Verify(unit => unit.FindById<Company>(email),
                Times.Once);*/
        }
        [TestMethod]
        //[ExpectedException(typeof(CompanyNotExistException))]
        public void shouldThrowCompanyNotFoundExceptionWhenCompanyNotExist()
        {
           /* string email = "notexsist@null.com";
            unitOfWork.Setup(unit => 
                unit.FindById<Company>(email)
                ).Throws(new CompanyNotExistException());
            service.LoginCompany(email, "");*/
        }
        [TestMethod]
        //[ExpectedException(typeof(WrongPasswordException))]
        public void shouldThrowWrongPasswordExceptionWhenPasswordIsWrong()
        {
            /*string email = company.Email;
            string wrongPassword = "wrong_password";
            company.PasswordHash = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8";
            Company challengedCompany = company;
            unitOfWork.Setup(unit => 
                unit.FindById<Company>(email)
                ).Returns(challengedCompany);
            service.LoginCompany(email, wrongPassword);
        
             */
         }
    }

}
