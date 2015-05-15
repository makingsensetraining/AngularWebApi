namespace Hiperion.Infrastructure.Mappings
{
    #region References

    using Automapper;
    using AutoMapper;
    using Domain;
    using Models;

    #endregion

    public class RoleMappers : IObjectMapperConfigurator
    {
        public void Apply()
        {
            Mapper.CreateMap<Role, RoleDto>();

            Mapper.CreateMap<RoleDto, Role>();
        }
    }
}