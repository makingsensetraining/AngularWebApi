namespace Hiperion.Migrations
{
    #region References

    using System.Data.Entity.Migrations;

    #endregion

    public partial class AgeAddedtoUser20150511daltamirano : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Age", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "Age");
        }
    }
}