namespace Hiperion.Infrastructure.Mappings
{
    using Automapper;
    using AutoMapper;
    using Domain;
    using Models;

    public class UserMappers : IObjectMapperConfigurator
    {
        public void Apply()
        {
            Mapper.CreateMap<User, UserDto>()
                .ForMember(user => user.Role, opt => opt.ResolveUsing<RoleMapper>());

            Mapper.CreateMap<UserDto, User>()
                .ForMember(user => user.RoleId, opt => opt.ResolveUsing<RoleMapper>());
        }
    }
}