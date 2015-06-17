using Hiperion.Infrastructure.Security;

namespace Hiperion.Repositories
{
    #region References

    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Domain;
    using Infrastructure.EF.Interfaces;
    using Interfaces;

    #endregion

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
                if (user.FirstName != null)
                    existingUser.FirstName = user.FirstName;

                if (user.LastName != null)
                    existingUser.LastName = user.LastName;

                if (user.Password != null)
                    existingUser.Password = user.Password;

                if (user.UserName != null)
                    existingUser.UserName = user.UserName;

                existingUser.Age = user.Age;

                if (user.CountryId != null)
                    existingUser.CountryId = user.CountryId;

                if (user.Password != null)
                    existingUser.Password = SecurityHelper.CalculateMD5Hash(user.Password);

                //Filter deleted roles and added roles
                var deletedRoles = existingUser.Roles.Except(user.Roles).ToList();
                var addedRoles = user.Roles.Except(existingUser.Roles).ToList();

                //Update roles
                deletedRoles.ForEach(role => existingUser.Roles.Remove(role));
                addedRoles.ForEach(role => existingUser.Roles.Add(role));

                _context.Entity<User>().AddOrUpdate(existingUser);

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

        public bool Login(string userName, string password)
        {
            return _context.Entity<User>().Where(user => user.UserName == userName && user.Password == password).Any();
        }

        public User GetUser(int id)
        {
            return _context.Entity<User>().FirstOrDefault(x => x.Id == id);
        }
    }
}