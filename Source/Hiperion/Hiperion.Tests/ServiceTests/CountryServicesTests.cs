namespace Hiperion.Tests.ServiceTests
{
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Repositories.Interfaces;
    using Services;

    #endregion

    [TestClass]
    public class CountryServicesTests
    {
        private Mock<ICountryRepository> CountryRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            CountryRepository = new Mock<ICountryRepository>();
            CountryRepository.Setup(x => x.GetAllValues())
                .Returns(ResourceLists.Countries.ToList());
            CountryRepository.Setup(x => x.SaveOrUpdateCountry(It.IsAny<Country>()));
            CountryRepository.Setup(x => x.DeleteCountry(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetAllCountriesSameCountTest()
        {
            var mapper = Mocking.MockMapper<IList<Country>, IList<CountryDto>>(ResourceLists.CountriesDto.ToList());
            var countryServices = new CountryServices(CountryRepository.Object, mapper.Object);

            var result = countryServices.GetAllCountries();

            Assert.IsTrue(result.Count() == ResourceLists.CountriesDto.Count);
        }

        [TestMethod]
        public void SaveOrUpdateCountriesTest()
        {
            var mapper = Mocking.MockMapper<IList<Country>, IList<CountryDto>>(ResourceLists.CountriesDto.ToList());
            var countryServices = new CountryServices(CountryRepository.Object, mapper.Object);

            countryServices.SaveOrUpdateCountry(new CountryDto());
        }

        [TestMethod]
        public void DeleteCountryTest()
        {
            var userServices = new CountryServices(CountryRepository.Object, null);

            userServices.DeleteCountry(1);
        }
    }
}