using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using IT_Recrutement_Link.Domain.Entities;
using Moq;
namespace IT_Recrutement_Link.Service.Test
{
    [TestClass]
    public class CompanyServiceTest
    {
        [TestMethod]
        public void shouldAddCompany()
        {
            /*
            //Build
            Mock<IBlobStorage> storage = new Mock<IBlobStorage>();
            MockUnitOfWork<Company> unitOfWork = new MockUnitOfWork<Company>();
            CompanyService service = new CompanyService(storage.Object, unitOfWork);
            IList<string> keywords = new List<string>(new string[] { "CS", "IT"});
            Company company = new Company();
            
            FileStream video = null;
            FileStream image = null;
            FileStream slide = null;
            //Operate
            service.AddCompany("name", video, image, slide, ActivitySectorEnum.Software_engeneering, 
                "36 Terry Street", CompanySizeEnum.small, new DateTime(2149, 10, 10), true, keywords);
            //Check
            //unitOfWork.getSavedEntity().;
            storage.Verify(store => store.upLoad(video));
            storage.Verify(store => store.upLoad(image));
            storage.Verify(store => store.upLoad(slide));
            Assert.IsTrue(unitOfWork.isAddCalledOnce());
            Assert.IsTrue(unitOfWork.isCommitCalledOnce()); 
            */   
        }
        
    }
    class MockUnitOfWork<T> : IUnitOfWork<T> where T :class
    {
        private int addCounter = 0;
        private int commitCounter = 0;
        private T savedEntity;
        public void Add(T entity)
        {
            savedEntity = entity;
            ++addCounter;
        }
        public void Commit()
        {
            ++commitCounter;
        }
        public bool isAddCalledOnce()
        {
            return addCounter == 1;
        }
        public bool isCommitCalledOnce()
        {
            return commitCounter == 1;
        }
        public T getSavedEntity()
        {
            return savedEntity;
        }
    }
}
