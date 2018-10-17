namespace GamesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdentityTables1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Role");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRole");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogin");
            RenameColumn(table: "dbo.Role", name: "Id", newName: "RoleID");
            DropPrimaryKey("dbo.UserRole");
            AddPrimaryKey("dbo.UserRole", new[] { "RoleId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserRole");
            AddPrimaryKey("dbo.UserRole", new[] { "UserId", "RoleId" });
            RenameColumn(table: "dbo.Role", name: "RoleID", newName: "Id");
            RenameTable(name: "dbo.UserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Role", newName: "AspNetRoles");
        }
    }
}
