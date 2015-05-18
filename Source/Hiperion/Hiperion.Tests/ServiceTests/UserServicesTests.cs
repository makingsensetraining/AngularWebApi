namespace Hiperion.Tests.ServiceTests
{
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Repositories.Interfaces;
    using Services;

    #endregion

    [TestClass]
    public class UserServicesTests
    {
        private Mock<IUserRepository> UserRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            UserRepository = new Mock<IUserRepository>();
            UserRepository.Setup(x => x.GetAllValues())
                .Returns(ResourceLists.Users.ToList());
            UserRepository.Setup(x => x.SaveOrUpdateUser(It.IsAny<User>()));
            UserRepository.Setup(x => x.DeleteUser(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetAllUsersSameCountTest()
        {
            var mapper = Mocking.MockMapper<IList<User>, IList<UserDto>>(ResourceLists.UsersDto.ToList());
            var userServices = new UserServices(UserRepository.Object, mapper.Object);

            var results = userServices.GetAllUsers();
            Assert.IsTrue(results.Count() == ResourceLists.Users.Count);
        }

        [TestMethod]
        public void SaveOrUpdateUserTest()
        {
            var mapper = Mocking.MockMapper<UserDto, User>(new User());
            var userServices = new UserServices(UserRepository.Object, mapper.Object);

            userServices.SaveOrUpdateUser(new UserDto());
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var mapper = Mocking.MockMapper<UserDto, User>(new User());
            var userServices = new UserServices(UserRepository.Object, mapper.Object);

            userServices.DeleteUser(1);
        }
    }
}