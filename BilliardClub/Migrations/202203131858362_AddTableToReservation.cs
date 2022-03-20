namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableToReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "BilliardTableId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "BilliardTableId");
            AddForeignKey("dbo.Reservations", "BilliardTableId", "dbo.BilliardTables", "BilliardTableId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "BilliardTableId", "dbo.BilliardTables");
            DropIndex("dbo.Reservations", new[] { "BilliardTableId" });
            DropColumn("dbo.Reservations", "BilliardTableId");
        }
    }
}
