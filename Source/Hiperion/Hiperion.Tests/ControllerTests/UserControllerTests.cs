namespace Hiperion.Tests.ControllerTests
{
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Controllers;
    using Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Services.Interfaces;

    #endregion

    [TestClass]
    public class UserControllerTests
    {
        private Mock<IUserServices> UserServices { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            UserServices = new Mock<IUserServices>();
            UserServices.Setup(x => x.GetAllUsers())
                .Returns(ResourceLists.UsersDto);
            UserServices.Setup(x => x.SaveOrUpdateUser(It.IsAny<UserDto>()));
            UserServices.Setup(x => x.DeleteUser(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetUsersTest()
        {
            var userController = new UserController(UserServices.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var response = userController.Get();
            IEnumerable<UserDto> userDtos;
            Assert.IsTrue(response.TryGetContentValue(out userDtos));
            Assert.IsTrue(userDtos.Count() == ResourceLists.UsersDto.Count);
        }

        [TestMethod]
        public void PostUserTest()
        {
            var userController = new UserController(UserServices.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = userController.Post(new UserDto());

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var userController = new UserController(UserServices.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = userController.Delete(0);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }
    }
}