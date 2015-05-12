using System.Collections.Generic;
using System.Linq;

namespace Hiperion.Repositories
{
    using System.Data.Entity;
    using Domain;
    using Infrastructure.EF.Interfaces;

    public class RoleRepository
    {
        private readonly IDbContext _context;

        public RoleRepository(IDbContext context)
        {
            _context = context;
        }

        public IList<Role> GetAllValues()
        {
            return _context.Entity<Role>().ToList();
        }

        public void SaveOrUpdateRole(Role role)
        {
            _context.Entry(role).State = role.Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = _context.Entity<Role>().Single(i => i.Id == id);
            _context.Entity<Role>().Remove(role);
            _context.SaveChanges();
        }
    }
}