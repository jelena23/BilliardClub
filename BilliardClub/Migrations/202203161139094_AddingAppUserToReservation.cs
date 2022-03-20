namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAppUserToReservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "ClientId", "dbo.Clients");
            DropIndex("dbo.Reservations", new[] { "ClientId" });
            AlterColumn("dbo.Reservations", "ClientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reservations", "ClientId");
            AddForeignKey("dbo.Reservations", "ClientId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ClientId", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ClientId" });
            AlterColumn("dbo.Reservations", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "ClientId");
            AddForeignKey("dbo.Reservations", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
    }
}
