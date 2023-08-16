namespace E_CommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Buyer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        BuyerID = c.Int(nullable: false, identity: true),
                        BuyerName = c.String(),
                    })
                .PrimaryKey(t => t.BuyerID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        SellerName = c.String(),
                    })
                .PrimaryKey(t => t.SellerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sellers");
            DropTable("dbo.Buyers");
        }
    }
}
