using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Hiperion.Domain.Repositories.Interfaces;
using Hiperion.Infrastructure.EF.Interfaces;

namespace Hiperion.Domain.Repositories
{
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
            var user = this._context.Entity<User>().Single(i => i.Id == id);
            _context.Entity<User>().Remove(user);
        }
    }
}