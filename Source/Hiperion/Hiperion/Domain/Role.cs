namespace Hiperion.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Roles")]
    public class Role : DomainEntity
    {
        [Key]
        public new int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}