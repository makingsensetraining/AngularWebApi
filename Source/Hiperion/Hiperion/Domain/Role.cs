namespace Hiperion.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Roles")]
    public class Role : DomainEntity
    {
        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}