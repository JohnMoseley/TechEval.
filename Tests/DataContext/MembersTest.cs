using Heuristics.TechEval.Core;
using Heuristics.TechEval.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Heuristics.TechEval.Tests.DataContext
{
    [TestClass]
    public class MembersTest
    {
        private readonly MembersRepository repository;
        private readonly Mock<IDataContext> context = new Mock<IDataContext>();
        public MembersTest()
        {
            repository = new MembersRepository(context.Object);
        }
        [TestMethod]
        public void ListMemberTest()
        {
            //// Arrange
            //int count = 100;
            //// Act
            //var list = BogusFakeData.GenerateMembers(count);
            //// Assert
            //Assert.AreEqual(count, list.Count);

            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void GetMemberByIdTest()
        {
            // Arrange
            int id = 5;
            int count = 100;
            var list = BogusFakeData.GenerateMembers(count);

            //context.Setup(x => x.Members)
            //    .Returns(list[id])
            // Act
            var member = repository.GetMemberById(id);

            // Assert
            Assert.AreEqual(id, member.Id);
        }

        [TestMethod]
        public void AddMemberTest()
        {
            // Arrange

            // Act

            // Assert
        }
        [TestMethod]
        public void EditMemberTest()
        {
            // Arrange

            // Act

            // Assert
        }

    }
}
