using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiperion.Services.Interfaces
{
    using Models;

    public interface IUserServices
    {
        IEnumerable<UserDto> GetAllUsers();

        bool SaveOrUpdateUser(UserDto userDto);

        void DeleteUser(int id);
    }
}
