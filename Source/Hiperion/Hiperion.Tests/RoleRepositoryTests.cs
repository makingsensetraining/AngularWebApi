namespace Hiperion.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Domain;
    using Infrastructure.EF;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositories;

    [TestClass]
    public class RoleRepositoryTests
    {
        private ICollection<Role> UserList { get; set; }
        private Mock<IDbSet<Role>> DbSetRoleMock { get; set; }

        private Mock<HiperionDbContext> DbContextMock { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            UserList = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Administrator"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                },
                new Role
                {
                    Id = 3,
                    Name = "Collaborator"
                }
            };

            DbSetRoleMock = new Mock<IDbSet<Role>>();
            DbSetRoleMock.Setup(m => m.Provider).Returns(UserList.AsQueryable().Provider);
            DbSetRoleMock.Setup(m => m.Expression).Returns(UserList.AsQueryable().Expression);
            DbSetRoleMock.Setup(m => m.ElementType).Returns(UserList.AsQueryable().ElementType);
            DbSetRoleMock.Setup(m => m.GetEnumerator()).Returns(UserList.AsQueryable().GetEnumerator());

            DbContextMock = new Mock<HiperionDbContext>();
            DbContextMock.Setup(x => x.Entity<Role>()).Returns(DbSetRoleMock.Object);
        }   

        [TestMethod]
        public void GetAllValuesTest()
        {
            var rolesRepository = new RoleRepository(DbContextMock.Object);
            var result = rolesRepository.GetAllValues();

            Assert.IsTrue(result.All(x => UserList.Contains(x)));
        }
    }
}