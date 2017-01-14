namespace CBB.HelpDesk.DbPekaoServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
        }
    }
}
