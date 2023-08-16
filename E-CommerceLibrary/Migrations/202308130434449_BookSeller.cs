namespace E_CommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookSeller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sellers", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sellers", "BookID");
            AddForeignKey("dbo.Sellers", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sellers", "BookID", "dbo.Books");
            DropIndex("dbo.Sellers", new[] { "BookID" });
            DropColumn("dbo.Sellers", "BookID");
        }
    }
}
