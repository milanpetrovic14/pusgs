namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTipKarte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipKartes",
                c => new
                {
                    Tip = c.String(nullable: false, maxLength: 128),
                    Stavka_IdStavke = c.Int(),
                })
                .PrimaryKey(t => t.Tip)
                .ForeignKey("dbo.Stavkas", t => t.Stavka_IdStavke)
                .Index(t => t.Stavka_IdStavke);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipKartes", "Stavka_IdStavke", "dbo.Stavkas");
            DropIndex("dbo.TipKartes", new[] { "Stavka_IdStavke" });
            DropTable("dbo.TipKartes");
        }
    }
}
