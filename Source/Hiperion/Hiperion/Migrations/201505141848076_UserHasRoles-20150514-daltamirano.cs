namespace Hiperion.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UserHasRoles20150514daltamirano : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            CreateTable(
                "dbo.UserHasRoles",
                c => new
                    {
                        Userid = c.Int(nullable: false),
                        Roleid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Userid, t.Roleid })
                .ForeignKey("dbo.Users", t => t.Userid, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Roleid, cascadeDelete: true)
                .Index(t => t.Userid)
                .Index(t => t.Roleid);
            
            DropColumn("dbo.Users", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Int());
            DropForeignKey("dbo.UserHasRoles", "Roleid", "dbo.Roles");
            DropForeignKey("dbo.UserHasRoles", "Userid", "dbo.Users");
            DropIndex("dbo.UserHasRoles", new[] { "Roleid" });
            DropIndex("dbo.UserHasRoles", new[] { "Userid" });
            DropTable("dbo.UserHasRoles");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
    }
}
