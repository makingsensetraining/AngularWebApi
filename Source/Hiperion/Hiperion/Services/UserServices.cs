namespace Hiperion.Services
{
    #region References

    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Domain;
    using Infrastructure.Security;
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
            _repository.SaveOrUpdateUser(user);

            return true;
        }

        public void DeleteUser(int id)
        {
            _repository.DeleteUser(id);
        }

        public bool SignUp(UserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Password))
                throw new ArgumentNullException("The user name or password is incorrect");

            userDto.Password = SecurityHelper.CalculateMD5Hash(userDto.Password);

            var user = _mapperEngine.Map<UserDto, User>(userDto);
            _repository.SaveOrUpdateUser(user);

            return true;
        }

        public bool Login(string userName, string password)
        {
            password = SecurityHelper.CalculateMD5Hash(password);
            return _repository.Login(userName, password);
        }
    }
}