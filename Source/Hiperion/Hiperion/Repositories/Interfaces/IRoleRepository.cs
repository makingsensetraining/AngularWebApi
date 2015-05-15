namespace Hiperion.Repositories.Interfaces
{
    #region References

    using System.Collections.Generic;
    using Domain;

    #endregion

    public interface IRoleRepository
    {
        IList<Role> GetAllValues();

        Role GetRole(int id);

        void SaveOrUpdateRole(Role role);

        void DeleteRole(int id);
    }
}