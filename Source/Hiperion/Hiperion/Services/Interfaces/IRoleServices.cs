namespace Hiperion.Services.Interfaces
{
    #region References

    using System.Collections.Generic;
    using Models;

    #endregion

    public interface IRoleServices
    {
        IEnumerable<RoleDto> GetAllRoles();

        bool SaveOrUpdateRole(RoleDto roleDto);

        void DeleteRole(int id);
    }
}