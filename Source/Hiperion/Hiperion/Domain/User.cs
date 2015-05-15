namespace Hiperion.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User : DomainEntity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}