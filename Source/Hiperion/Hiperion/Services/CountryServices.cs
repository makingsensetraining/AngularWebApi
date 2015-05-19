namespace Hiperion.Services
{
    #region References

    using System.Collections.Generic;
    using AutoMapper;
    using Domain;
    using Interfaces;
    using Models;
    using Repositories.Interfaces;

    #endregion

    public class CountryServices : ICountryServices
    {
        private readonly IMappingEngine _mapperEngine;
        private readonly ICountryRepository _repository;

        public CountryServices(ICountryRepository repository, IMappingEngine mapperEngine)
        {
            _repository = repository;
            _mapperEngine = mapperEngine;
        }

        public IEnumerable<CountryDto> GetAllCountries()
        {
            var countries = _repository.GetAllValues();

            var countryDtos = _mapperEngine.Map<IList<Country>, IList<CountryDto>>(countries);

            return countryDtos;
        }

        public bool SaveOrUpdateCountry(CountryDto countryDto)
        {
            var country = _mapperEngine.Map<CountryDto, Country>(countryDto);

            //add some bussines logic before update DB

            _repository.SaveOrUpdateCountry(country);

            return true;
        }

        public void DeleteCountry(int id)
        {
            //add some bussines logic before update DB

            _repository.DeleteCountry(id);
        }
    }
}