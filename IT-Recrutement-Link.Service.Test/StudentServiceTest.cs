using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using IT_Recrutement_Link.Domain.Entities;
using Moq;

namespace IT_Recrutement_Link.Service.Test
{
    [TestClass]
    public class StudentServiceTest
    {
        [TestMethod]
        public void ShouldAddStudent()
        {
            Mock<IBlobStorage> storage = new Mock<IBlobStorage>();
            storage.Setup(st => st.upLoad(It.IsAny<FileStream>())).Returns("url");
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            IList<string> keywords = new List<string>(new string[] { "CSs", "IT" });
            List<string> Diplome = new List<string>(new string[] {"licence", "ingenieurie"});
            List<string> University = new List<string>(new string[] {"ESPRIT", "ESTI"});
            List<string> Formation = new List<string>(new string[] {"", ""});
            List<string> Experience = new List<string>(new string[] {""});
            Student student = new Student
            {
                Name = "shikamaru",
                LastName = "Nara",
                Email = "shikamaru.naru@konoha.jp",
                DateNaissance = new DateTime(1990,12,22),
                Diplome = Diplome,
                University = University,
                Formation = Formation,
                Experience = Experience,
                CompetenceSectorName = CompetenceSectorEnum.cloud_computing,
                Keywords = keywords
            };
            FileStream video = File.Open("video", FileMode.Create);
            FileStream image = File.Open("image", FileMode.Create);
            FileStream slides = File.Open("slides", FileMode.Create);

            StudentService service = new StudentService(storage.Object, unitOfWork.Object);

            service.AddStudent(student, video, image, slides);


            storage.Verify(store => store.upLoad(video), Times.Once);
            storage.Verify(store => store.upLoad(image), Times.Once);
            storage.Verify(store => store.upLoad(slides), Times.Once);


            Assert.AreEqual("url", student.VideoUrl);
            Assert.AreEqual("url", student.ProfilePictureUrl);
            Assert.AreEqual("url", student.SlidesUrl);


            unitOfWork.Verify(unit => unit.Add<Student>(student), Times.Once());
            unitOfWork.Verify(unit => unit.Commit(), Times.Once());

            video.Dispose();
            image.Dispose();
            slides.Dispose();

        }
    }
}
