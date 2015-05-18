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

    public class UserServices : IUserServices
    {
        private readonly IMappingEngine _mapperEngine;
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository, IMappingEngine mapperEngine)
        {
            _repository = repository;
            _mapperEngine = mapperEngine;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _repository.GetAllValues();

            var userDtos = _mapperEngine.Map<IList<User>, IList<UserDto>>(users);

            return userDtos;
        }

        public bool SaveOrUpdateUser(UserDto userDto)
        {
            var user = _mapperEngine.Map<UserDto, User>(userDto);

            //add some bussines logic before update DB
            _repository.SaveOrUpdateUser(user);

            return true;
        }

        public void DeleteUser(int id)
        {
            //add some bussines logic before update DB

            _repository.DeleteUser(id);
        }
    }
}