namespace Hiperion.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class DomainEntity
    {
        [Key]
        public int Id { get; set; }
    }
}