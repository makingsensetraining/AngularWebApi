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
    public class RoleControllerTests
    {
        private Mock<IRoleServices> RoleServices { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            RoleServices = new Mock<IRoleServices>();
            RoleServices.Setup(x => x.GetAllRoles())
                .Returns(ResourceLists.RolesDto);
            RoleServices.Setup(x => x.SaveOrUpdateRole(It.IsAny<RoleDto>()));
            RoleServices.Setup(x => x.DeleteRole(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetUsersTest()
        {
            var roleController = new RoleController(RoleServices.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var response = roleController.Get();
            IEnumerable<RoleDto> roleDtos;
            Assert.IsTrue(response.TryGetContentValue(out roleDtos));
            Assert.IsTrue(roleDtos.Count() == ResourceLists.RolesDto.Count);
        }

        [TestMethod]
        public void PostUserTest()
        {
            var roleController = new RoleController(RoleServices.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = roleController.Post(new RoleDto());
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var userController = new RoleController(RoleServices.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = userController.Delete(0);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }
    }
}