namespace Hiperion.Migrations
{
    #region References

    using System.Data.Entity.Migrations;

    #endregion

    public partial class UserNameAndPasswordAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(false));
            AddColumn("dbo.Users", "Password", c => c.String(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "UserName");
        }
    }
}