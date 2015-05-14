namespace Hiperion.Repositories
{
    using System.Collections.Generic;
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
            if (user.Id != 0)
            {
                var original = _context.Entity<User>().SingleOrDefault(x => x.Id == user.Id);
                if (original != null)
                    original.Roles = user.Roles;
                _context.SaveChanges();
            }
            else
            {
                _context.Entity<User>().Add(user);
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Entity<User>().Single(i => i.Id == id);
            _context.Entity<User>().Remove(user);
            _context.SaveChanges();
        }
    }
}