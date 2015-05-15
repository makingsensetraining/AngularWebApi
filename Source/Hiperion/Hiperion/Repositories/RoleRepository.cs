namespace Hiperion.Repositories
{
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Infrastructure.EF.Interfaces;
    using Interfaces;

    #endregion

    public class RoleRepository : IRoleRepository
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

        public Role GetRole(int id)
        {
            return _context.Entity<Role>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveOrUpdateRole(Role role)
        {
            if (role.Id != 0)
            {
                var existingRole = _context.Entity<Role>().FirstOrDefault(r => r.Id == role.Id);
                if (existingRole == null) return;

                var attachedRole = _context.Entry(existingRole);
                attachedRole.CurrentValues.SetValues(role);

                _context.SaveChanges();
            }
            else
            {
                _context.Entity<Role>().Add(role);
                _context.SaveChanges();
            }
        }

        public void DeleteRole(int id)
        {
            var role = _context.Entity<Role>().Single(i => i.Id == id);
            _context.Entity<Role>().Remove(role);
            _context.SaveChanges();
        }
    }
}