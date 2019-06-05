namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTipPutnika : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipPutnikas",
                c => new
                {
                    Tip = c.String(nullable: false, maxLength: 128),
                    Koeficijet = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Tip);
        }
        
        public override void Down()
        {
            DropTable("dbo.TipPutnikas");
        }
    }
}
