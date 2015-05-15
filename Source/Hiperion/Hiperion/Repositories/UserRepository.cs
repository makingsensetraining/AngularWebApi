namespace Hiperion.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
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
                var existingUser = _context.Entity<User>().SingleOrDefault(u => u.Id == user.Id);
                if (existingUser == null) return;

                //Update scalar values
                var attachedUser = _context.Entry(existingUser);
                attachedUser.CurrentValues.SetValues(user);

                //Filter deleted roles and added roles
                var deletedRoles = existingUser.Roles.Except(user.Roles).ToList();
                var addedRoles = user.Roles.Except(existingUser.Roles).ToList();

                //Update roles
                deletedRoles.ForEach(role => existingUser.Roles.Remove(role));
                addedRoles.ForEach(role => existingUser.Roles.Add(role));

                _context.SaveChanges();
            }
            else
            {
                _context.Entity<User>().AddOrUpdate(user);
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