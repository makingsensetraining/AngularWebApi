﻿namespace Hiperion.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Domain;
    using Infrastructure.EF.Interfaces;
    using Interfaces;

    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _context;

        public UserRepository(IDbContext context)
        {
            _context = context;
        }

        public IList<User> GetAllValues()
        {
            return _context.Entity<User>().ToList();
        }

        public void SaveOrUpdateUser(User user)
        {
            _context.Entry(user).State = user.Id == 0 ? EntityState.Added : EntityState.Modified;
        }

        public void DeleteUser(int id)
        {
            User user = _context.Entity<User>().Single(i => i.Id == id);
            _context.Entity<User>().Remove(user);
        }
    }
}