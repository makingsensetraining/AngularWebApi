namespace Hiperion.Tests.Helpers
{
    #region References

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Domain;
    using Models;

    #endregion

    public static class ResourceLists
    {
        static ResourceLists()
        {
            Roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Administrator"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                },
                new Role
                {
                    Id = 3,
                    Name = "Collaborator"
                }
            };

            RolesDto = new List<RoleDto>
            {
                new RoleDto
                {
                    Id = 1,
                    Name = "Administrator"
                },
                new RoleDto
                {
                    Id = 2,
                    Name = "User"
                },
                new RoleDto
                {
                    Id = 3,
                    Name = "Collaborator"
                }
            };

            UsersDto = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 33,
                    Roles = new Collection<RoleDto>
                    {
                        new RoleDto
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new RoleDto
                        {
                            Id = 2,
                            Name = "User"
                        }
                    }
                },
                new UserDto
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Age = 22,
                    Roles = new Collection<RoleDto>
                    {
                        new RoleDto
                        {
                            Id = 3,
                            Name = "Collaborator"
                        },
                        new RoleDto
                        {
                            Id = 2,
                            Name = "User"
                        }
                    }
                }
            };

            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 33,
                    Roles = new Collection<Role>
                    {
                        new Role
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new Role
                        {
                            Id = 2,
                            Name = "User"
                        }
                    }
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Age = 22,
                    Roles = new Collection<Role>
                    {
                        new Role
                        {
                            Id = 3,
                            Name = "Collaborator"
                        },
                        new Role
                        {
                            Id = 2,
                            Name = "User"
                        }
                    }
                }
            };
        }

        public static List<RoleDto> RolesDto { get; set; }

        public static List<Role> Roles { get; set; }

        public static List<User> Users { get; set; }

        public static List<UserDto> UsersDto { get; set; }
    }
}