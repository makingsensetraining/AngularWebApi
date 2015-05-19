namespace Hiperion.Migrations
{
    #region References

    using System.Data.Entity.Migrations;

    #endregion

    public partial class Countries20150518daltamirano : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Users", "CountryId", c => c.Int());
            CreateIndex("dbo.Users", "CountryId");
            AddForeignKey("dbo.Users", "CountryId", "dbo.Countries", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropIndex("dbo.Users", new[] {"CountryId"});
            DropColumn("dbo.Users", "CountryId");
            DropTable("dbo.Countries");
        }
    }
}