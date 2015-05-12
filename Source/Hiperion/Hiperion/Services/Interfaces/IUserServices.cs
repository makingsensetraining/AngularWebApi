namespace Hiperion.Services.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IUserServices
    {
        IEnumerable<UserDto> GetAllUsers();

        bool SaveOrUpdateUser(UserDto userDto);

        void DeleteUser(int id);
    }
}