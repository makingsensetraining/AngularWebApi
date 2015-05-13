namespace Hiperion.Domain
{
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

        [ForeignKey("Role")]
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}