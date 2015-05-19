namespace Hiperion.Repositories
{
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Infrastructure.EF.Interfaces;
    using Interfaces;

    #endregion

    public class CountryRepository : ICountryRepository
    {
        private readonly IDbContext _context;

        public CountryRepository(IDbContext context)
        {
            _context = context;
        }

        public IList<Country> GetAllValues()
        {
            return _context.Entity<Country>().ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Entity<Country>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveOrUpdateCountry(Country country)
        {
            if (country.Id != 0)
            {
                var existingCountry = _context.Entity<Country>().FirstOrDefault(r => r.Id == country.Id);
                if (existingCountry == null) return;

                var attachedCountry = _context.Entry(existingCountry);
                attachedCountry.CurrentValues.SetValues(country);

                _context.SaveChanges();
            }
            else
            {
                _context.Entity<Country>().Add(country);
                _context.SaveChanges();
            }
        }

        public void DeleteCountry(int id)
        {
            var country = _context.Entity<Country>().Single(i => i.Id == id);
            _context.Entity<Country>().Remove(country);
            _context.SaveChanges();
        }
    }
}