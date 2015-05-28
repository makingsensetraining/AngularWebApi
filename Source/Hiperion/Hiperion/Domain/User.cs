namespace Hiperion.Domain
{
    #region References

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    [Table("Users")]
    public class User : DomainEntity
    {
        [Column("UserName")]
        [Required]
        public string UserName { get; set; }

        [Column("Password")]
        [Required]
        public string Password { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}