namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeSlotResrevations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            AddColumn("dbo.Reservations", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "ClientId");
            AddForeignKey("dbo.Reservations", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ClientId", "dbo.Clients");
            DropIndex("dbo.Reservations", new[] { "ClientId" });
            DropColumn("dbo.Reservations", "ClientId");
            DropTable("dbo.Clients");
        }
    }
}
