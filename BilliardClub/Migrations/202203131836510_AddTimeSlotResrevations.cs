namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeSlotResrevations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "EndTime");
            DropColumn("dbo.Reservations", "StartTime");
        }
    }
}
