namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Birthdate");
        }
    }
}
