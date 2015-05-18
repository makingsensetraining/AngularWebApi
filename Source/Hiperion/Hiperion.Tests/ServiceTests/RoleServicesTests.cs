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
    public class RoleServicesTests
    {
        private Mock<IRoleRepository> RoleRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            RoleRepository = new Mock<IRoleRepository>();
            RoleRepository.Setup(x => x.GetAllValues())
                .Returns(ResourceLists.Roles.ToList());
            RoleRepository.Setup(x => x.SaveOrUpdateRole(It.IsAny<Role>()));
            RoleRepository.Setup(x => x.DeleteRole(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetAllRolesSameCountTest()
        {
            var mapper = Mocking.MockMapper<IList<Role>, IList<RoleDto>>(ResourceLists.RolesDto.ToList());
            var roleServices = new RoleServices(RoleRepository.Object, mapper.Object);

            var result = roleServices.GetAllRoles();

            Assert.IsTrue(result.Count() == ResourceLists.RolesDto.Count);
        }

        [TestMethod]
        public void SaveOrUpdateRoleTest()
        {
            var mapper = Mocking.MockMapper<RoleDto, Role>(new Role());
            var userServices = new RoleServices(RoleRepository.Object, mapper.Object);

            userServices.SaveOrUpdateRole(new RoleDto());
        }

        [TestMethod]
        public void DeleteRoleTest()
        {
            var userServices = new RoleServices(RoleRepository.Object, null);

            userServices.DeleteRole(1);
        }
    }
}