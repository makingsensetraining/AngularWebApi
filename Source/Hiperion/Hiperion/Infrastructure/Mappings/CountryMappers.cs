namespace Hiperion.Infrastructure.Mappings
{
    #region References

    using Automapper;
    using AutoMapper;
    using Domain;
    using Models;

    #endregion

    public class CountryMappers : IObjectMapperConfigurator
    {
        public void Apply()
        {
            Mapper.CreateMap<Country, CountryDto>();

            Mapper.CreateMap<CountryDto, Country>();
        }
    }
}