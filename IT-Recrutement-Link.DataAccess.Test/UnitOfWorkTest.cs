using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT_Recrutement_Link.Domain.Entities;
using IT_Recrutement_Link.DataAccess.Infrastructure;
using Moq;

namespace IT_Recrutement_Link.DataAccess.Test
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void ShouldAddEntity()
        {
            Student s = new Student("blob");
            UnitOfWork<Student> unit = new UnitOfWork<Student>();
            Mock<Context> m = new Mock<Context>();
            m.Setup(u.save(s)).returns(true).verifiable();
            unit.Add(s);
        }
    }
}
