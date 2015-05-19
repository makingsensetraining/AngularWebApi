namespace Hiperion.Domain
{
    #region References

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    public class Country : DomainEntity
    {
        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}