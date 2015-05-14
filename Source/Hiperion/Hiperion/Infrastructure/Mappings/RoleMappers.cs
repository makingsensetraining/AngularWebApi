namespace Hiperion.Infrastructure.Mappings
{
    using Automapper;
    using AutoMapper;
    using Domain;
    using Models;

    public class RoleMappers : IObjectMapperConfigurator
    {
        public void Apply()
        {
            Mapper.CreateMap<Role, RoleDto>();

            Mapper.CreateMap<RoleDto, Role>();
        }
    }
}