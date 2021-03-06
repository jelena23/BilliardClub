namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeClientName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Clients", "FirstName");
            DropColumn("dbo.Clients", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Clients", "FirstName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Clients", "Name");
        }
    }
}
