namespace Hiperion.Infrastructure.Mappings
{
    using AutoMapper;
    using Domain;

    public class RoleMapper : ValueResolver<Role, int>
    {
        protected override int ResolveCore(Role source)
        {
            return source.Id;
        }
    }
}