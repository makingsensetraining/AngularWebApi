using System.Collections.Generic;

namespace Hiperion.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IList<User> GetAllValues();

        void SaveOrUpdateUser(User user);

        void DeleteUser(int id);
    }
}
