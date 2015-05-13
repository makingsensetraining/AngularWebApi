namespace Hiperion.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Roles")]
    public class Role : DomainEntity
    {
        [Column("Name")]
        public string Name { get; set; }
    }
}