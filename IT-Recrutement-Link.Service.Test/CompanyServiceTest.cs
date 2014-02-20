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

            //Build
            Mock<IBlobStorage> storage = new Mock<IBlobStorage>();
            storage.Setup(st => st.upLoad(It.IsAny<FileStream>())).Returns("url");
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            IList<string> keywords = new List<string>(new string[] { "CS", "IT" });
            Company company = new Company
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
            FileStream video = File.Open("video", FileMode.Create);
            FileStream image = File.Open("image", FileMode.Create);
            FileStream slides = File.Open("slides", FileMode.Create);
            string password = "pass";
            CompanyService service = new CompanyService(storage.Object, unitOfWork.Object);
            
            //Operate
            service.AddCompany(company, password, video, 
                image, slides);       
            
            //check
            storage.Verify(store => store.upLoad(video), Times.Once);
            storage.Verify(store => store.upLoad(image), Times.Once);
            storage.Verify(store => store.upLoad(slides), Times.Once);
            
            Assert.AreNotEqual(password, company.PasswordHash); 
            Assert.AreEqual("url", company.VideoUrl);
            Assert.AreEqual("url", company.LogoPictureUrl);
            Assert.AreEqual("url", company.SlidesUrl);
            
            unitOfWork.Verify(unit => unit.Add<Company>(company), Times.Once());
            unitOfWork.Verify(unit => unit.Commit(), Times.Once());
            
            //Cleanup
            video.Dispose();
            image.Dispose();
            slides.Dispose();
        }

    }
    
}
