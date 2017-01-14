namespace CBB.HelpDesk.DbPekaoServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAgeOnUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Users", "Age", "Age2");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Users", "Age2", "Age");
        }
    }
}
