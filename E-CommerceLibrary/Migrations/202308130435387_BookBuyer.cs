namespace E_CommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookBuyer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Buyers", "BookID");
            AddForeignKey("dbo.Buyers", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buyers", "BookID", "dbo.Books");
            DropIndex("dbo.Buyers", new[] { "BookID" });
            DropColumn("dbo.Buyers", "BookID");
        }
    }
}
