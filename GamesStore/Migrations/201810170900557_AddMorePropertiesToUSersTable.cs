namespace GamesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMorePropertiesToUSersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.AspNetUsers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Image");
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
