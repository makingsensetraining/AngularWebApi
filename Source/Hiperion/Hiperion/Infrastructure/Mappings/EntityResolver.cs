﻿namespace Hiperion.Infrastructure.Mappings
{
    using System.Linq;
    using AutoMapper;
    using Domain;
    using EF.Interfaces;

    public class EntityResolver<T> : ValueResolver<int, T> where T : DomainEntity
    {
        private readonly IDbContext _dbContext;

        public EntityResolver(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override T ResolveCore(int source)
        {
            return _dbContext.Entity<T>().FirstOrDefault(x => x.Id == source);
        }
    }
}