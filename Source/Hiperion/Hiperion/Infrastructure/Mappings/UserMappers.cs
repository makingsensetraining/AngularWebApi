namespace Hiperion.Infrastructure.Mappings
{
    #region References

    using Automapper;
    using AutoMapper;
    using Domain;
    using Models;

    #endregion

    public class UserMappers : IObjectMapperConfigurator
    {
        public void Apply()
        {
            Mapper.CreateMap<User, UserDto>();

            Mapper.CreateMap<UserDto, User>()
                .ForMember(user => user.Roles,
                    opt => opt.ResolveUsing<ManyToManyEntityResolver<RoleDto, Role>>().FromMember(user => user.Roles));
        }
    }
}