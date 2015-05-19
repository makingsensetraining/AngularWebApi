namespace Hiperion.Repositories.Interfaces
{
    #region References

    using System.Collections.Generic;
    using Domain;

    #endregion

    public interface ICountryRepository
    {
        IList<Country> GetAllValues();

        Country GetCountry(int id);

        void SaveOrUpdateCountry(Country country);

        void DeleteCountry(int id);
    }
}