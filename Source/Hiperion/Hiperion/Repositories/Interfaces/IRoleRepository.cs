namespace Hiperion.Repositories.Interfaces
{
    using System.Collections.Generic;
    using Domain;

    public interface IRoleRepository
    {
        IList<Role> GetAllValues();

        Role GetRole(int id);

        void SaveOrUpdateRole(Role role);

        void DeleteRole(int id);
    }
}