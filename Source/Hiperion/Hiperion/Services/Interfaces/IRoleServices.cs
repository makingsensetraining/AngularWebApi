namespace Hiperion.Services.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IRoleServices
    {
        IEnumerable<RoleDto> GetAllRoles();

        bool SaveOrUpdateRole(RoleDto roleDto);

        void DeleteRole(int id);
    }
}