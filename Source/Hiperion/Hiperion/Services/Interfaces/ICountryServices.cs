namespace Hiperion.Services.Interfaces
{
    #region References

    using System.Collections.Generic;
    using Models;

    #endregion

    public interface ICountryServices
    {
        IEnumerable<CountryDto> GetAllCountries();

        bool SaveOrUpdateCountry(CountryDto country);

        void DeleteCountry(int id);
    }
}