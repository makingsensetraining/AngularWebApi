namespace Hiperion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameAndPasswordAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
