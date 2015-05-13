namespace Hiperion.Services
{
    using System.Collections.Generic;
    using AutoMapper;
    using Domain;
    using Interfaces;
    using Models;
    using Repositories.Interfaces;

    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _repository;

        public RoleServices(IRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RoleDto> GetAllRoles()
        {
            var roles = _repository.GetAllValues();

            var roleDtos = Mapper.Map<IList<Role>, IList<RoleDto>>(roles);

            return roleDtos;
        }

        public bool SaveOrUpdateRole(RoleDto roleDto)
        {
            var role = Mapper.Map<RoleDto, Role>(roleDto);

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