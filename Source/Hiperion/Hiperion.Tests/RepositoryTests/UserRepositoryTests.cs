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
    public class UserRepositoryTests
    {
        private IMock<IDbSet<User>> DbSetUserMock { get; set; }

        private IMock<IDbContext> DbContextMock { get; set; }

        private UserRepository UsersRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            DbSetUserMock = Mocking.MockDbSet(ResourceLists.Users.ToList());
            DbContextMock = Mocking.MockDbContext(DbSetUserMock);

            UsersRepository = new UserRepository(DbContextMock.Object);
        }

        [TestMethod]
        public void GetAllValuesTest()
        {
            var result = UsersRepository.GetAllValues();

            Assert.IsTrue(result.All(x => ResourceLists.Users.Contains(x)));
        }

        [TestMethod]
        public void GetRoleTest()
        {
            var expected = ResourceLists.Users.First();
            var result = UsersRepository.GetUser(expected.Id);

            Assert.IsTrue(result.Equals(expected));
        }
    }
}