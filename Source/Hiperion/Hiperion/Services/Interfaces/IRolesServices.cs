namespace Hiperion.Services.Interfaces
{
    using System.Collections.Generic;
    using Domain;
    using Models;

    public interface IRolesServices
    {
        IEnumerable<RoleDto> GetAllRoles();

        bool SaveOrUpdateRole(RoleDto roleDto);

        void DeleteRole(int id);
    }
}