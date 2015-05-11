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
            Mapper.CreateMap<User, UserDto>();

            Mapper.CreateMap<UserDto, User>();
        }
    }
}