namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStavka : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stavkas",
                c => new
                {
                    IdStavke = c.Int(nullable: false, identity: true),
                    Cena = c.Double(nullable: false),
                    Cenovnik_Id = c.Int(),
                    TipKarte_Tip = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.IdStavke)
                .ForeignKey("dbo.Cenovniks", t => t.Cenovnik_Id)
                .ForeignKey("dbo.TipKartes", t => t.TipKarte_Tip)
                .Index(t => t.Cenovnik_Id)
                .Index(t => t.TipKarte_Tip);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stavkas", "TipKarte_Tip", "dbo.TipKartes");
            DropForeignKey("dbo.Stavkas", "Cenovnik_Id", "dbo.Cenovniks");
            DropIndex("dbo.Stavkas", new[] { "TipKarte_Tip" });
            DropIndex("dbo.Stavkas", new[] { "Cenovnik_Id" });
            DropTable("dbo.Stavkas");
        }
    }
}
