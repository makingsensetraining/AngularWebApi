using System.Collections.Generic;
using Hiperion.Domain;

namespace Hiperion.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IList<User> GetAllValues();

        void SaveOrUpdateUser(User user);

        void DeleteUser(int id);
    }
}
