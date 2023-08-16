namespace E_CommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publisher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(),
                    })
                .PrimaryKey(t => t.PublisherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publishers");
        }
    }
}
