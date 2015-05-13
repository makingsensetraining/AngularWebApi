namespace Hiperion.Infrastructure.Mappings
{
    using AutoMapper;
    using Domain;
    using Repositories.Interfaces;

    public class IntToRoleMapper : ValueResolver<int, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public IntToRoleMapper(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        protected override Role ResolveCore(int source)
        {
            return _roleRepository.GetRole(source);
        }
    }
}