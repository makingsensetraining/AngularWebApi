namespace Hiperion.Services
{
    #region References

    using System.Collections.Generic;
    using AutoMapper;
    using Domain;
    using Interfaces;
    using Models;
    using Repositories.Interfaces;

    #endregion

    public class RoleServices : IRoleServices
    {
        private readonly IMappingEngine _mapperEngine;
        private readonly IRoleRepository _repository;

        public RoleServices(IRoleRepository repository, IMappingEngine mapperEngine)
        {
            _repository = repository;
            _mapperEngine = mapperEngine;
        }

        public IEnumerable<RoleDto> GetAllRoles()
        {
            var roles = _repository.GetAllValues();

            var roleDtos = _mapperEngine.Map<IList<Role>, IList<RoleDto>>(roles);

            return roleDtos;
        }

        public bool SaveOrUpdateRole(RoleDto roleDto)
        {
            var role = _mapperEngine.Map<RoleDto, Role>(roleDto);

            //add some bussines logic before update DB

            _repository.SaveOrUpdateRole(role);

            return true;
        }

        public void DeleteRole(int id)
        {
            //add some bussines logic before update DB

            _repository.DeleteRole(id);
        }
    }
}