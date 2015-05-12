using System.Collections.Generic;

namespace Hiperion.Repositories.Interfaces
{
    using Domain;

    public interface IRoleRepository
    {
        IList<Role> GetAllValues();

        void SaveOrUpdateRole(Role role);

        void DeleteRole(int id);
    }
}
