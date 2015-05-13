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
                .ForMember(user => user.Role, opt => opt.MapFrom(entity => entity.RoleId));

            Mapper.CreateMap<UserDto, User>()
                .ForMember(user => user.Role, opt => opt.ResolveUsing<IntToRoleMapper>().FromMember(user => user.Role))
                .ForMember(user => user.RoleId, opt => opt.MapFrom(entity => entity.Role));
        }
    }
}