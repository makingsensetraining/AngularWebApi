namespace Hiperion.Infrastructure.Mappings
{
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Domain;
    using EF.Interfaces;
    using Models;

    #endregion

    public class ManyToManyEntityResolver<T, U> : ValueResolver<IEnumerable<T>, IEnumerable<U>>
        where T : ModelEntity //Dto
        where U : DomainEntity //EF entities
    {
        private readonly IDbContext _dbContext;

        public ManyToManyEntityResolver(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override IEnumerable<U> ResolveCore(IEnumerable<T> source)
        {
            return source.Select(item => _dbContext.Entity<U>().FirstOrDefault(x => x.Id == item.Id));
        }
    }
}