namespace Hiperion.Domain
{
    #region References

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class DomainEntity
    {
        [Key]
        public int Id { get; set; }
    }
}