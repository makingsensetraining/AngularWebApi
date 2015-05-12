namespace Hiperion.Services
{
    using System.Collections.Generic;
    using AutoMapper;
    using Domain;
    using Interfaces;
    using Models;
    using Repositories.Interfaces;

    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _repository.GetAllValues();

            var userDtos = Mapper.Map<IList<User>, IList<UserDto>>(users);

            return userDtos;
        }

        public bool SaveOrUpdateUser(UserDto userDto)
        {
            var user = Mapper.Map<UserDto, User>(userDto);

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