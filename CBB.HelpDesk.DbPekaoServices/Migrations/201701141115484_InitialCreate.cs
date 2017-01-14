namespace CBB.HelpDesk.DbPekaoServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUser_UserId = c.Int(),
                        Ticket_TicketId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.CreateUser_UserId)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketId)
                .Index(t => t.CreateUser_UserId)
                .Index(t => t.Ticket_TicketId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Priority = c.Int(nullable: false),
                        Location = c.String(),
                        Status = c.Int(nullable: false),
                        Category_CategoryId = c.Int(),
                        CreateUser_UserId = c.Int(),
                        CurrentUser_UserId = c.Int(),
                        ReferenceTicket_TicketId = c.Int(),
                        UpdateUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Users", t => t.CreateUser_UserId)
                .ForeignKey("dbo.Users", t => t.CurrentUser_UserId)
                .ForeignKey("dbo.Tickets", t => t.ReferenceTicket_TicketId)
                .ForeignKey("dbo.Users", t => t.UpdateUser_UserId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.CreateUser_UserId)
                .Index(t => t.CurrentUser_UserId)
                .Index(t => t.ReferenceTicket_TicketId)
                .Index(t => t.UpdateUser_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Ticket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "UpdateUser_UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "ReferenceTicket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "CurrentUser_UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "CreateUser_UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Comments", "CreateUser_UserId", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "UpdateUser_UserId" });
            DropIndex("dbo.Tickets", new[] { "ReferenceTicket_TicketId" });
            DropIndex("dbo.Tickets", new[] { "CurrentUser_UserId" });
            DropIndex("dbo.Tickets", new[] { "CreateUser_UserId" });
            DropIndex("dbo.Tickets", new[] { "Category_CategoryId" });
            DropIndex("dbo.Comments", new[] { "Ticket_TicketId" });
            DropIndex("dbo.Comments", new[] { "CreateUser_UserId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
