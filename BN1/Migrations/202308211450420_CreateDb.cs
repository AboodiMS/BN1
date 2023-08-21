namespace BN1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Table1",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Number = c.Int(nullable: false),
                        Desimal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateAt = c.DateTime(nullable: false),
                        CreateBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Table1");
        }
    }
}
