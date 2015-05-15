namespace Hiperion.Tests.RepositoryTests
{
    #region References

    using System.Data.Entity;
    using System.Linq;
    using Domain;
    using Helpers;
    using Infrastructure.EF.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositories;

    #endregion

    [TestClass]
    public class RoleRepositoryTests
    {
        private IMock<IDbSet<Role>> DbSetRoleMock { get; set; }

        private IMock<IDbContext> DbContextMock { get; set; }

        private RoleRepository RolesRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            DbSetRoleMock = Mocking.MockDbSet(ResourceLists.Roles.ToList());
            DbContextMock = Mocking.MockDbContext(DbSetRoleMock);

            RolesRepository = new RoleRepository(DbContextMock.Object);
        }

        [TestMethod]
        public void GetAllValuesTest()
        {
            var result = RolesRepository.GetAllValues();

            Assert.IsTrue(result.All(x => ResourceLists.Roles.Contains(x)));
        }

        [TestMethod]
        public void GetRoleTest()
        {
            var expected = ResourceLists.Roles.First();
            var result = RolesRepository.GetRole(expected.Id);

            Assert.IsTrue(result.Equals(expected));
        }
    }
}