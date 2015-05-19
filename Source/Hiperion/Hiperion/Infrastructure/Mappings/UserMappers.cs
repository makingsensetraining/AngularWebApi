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
            Mapper.CreateMap<User, UserDto>()
                .ForMember(user => user.Country, opt => opt.MapFrom(user => user.CountryId));

            Mapper.CreateMap<UserDto, User>()
                .ForMember(user => user.Country,
                    opt => opt.ResolveUsing<EntityResolver<Country>>().FromMember(user => user.Country))
                .ForMember(user => user.Roles,
                    opt => opt.ResolveUsing<ManyToManyEntityResolver<RoleDto, Role>>().FromMember(user => user.Roles));
        }
    }
}