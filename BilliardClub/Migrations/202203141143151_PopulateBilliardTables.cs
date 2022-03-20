namespace BilliardClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBilliardTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BilliardTables (Position) VALUES ('L1')");
            Sql("INSERT INTO BilliardTables (Position) VALUES ('L2')");
            Sql("INSERT INTO BilliardTables (Position) VALUES ('L3')");
            Sql("INSERT INTO BilliardTables (Position) VALUES ('R1')");
            Sql("INSERT INTO BilliardTables (Position) VALUES ('R2')");
            Sql("INSERT INTO BilliardTables (Position) VALUES ('R3')");

        }
        
        public override void Down()
        {
        }
    }
}
