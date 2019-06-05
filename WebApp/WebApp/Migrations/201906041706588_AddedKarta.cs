namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKarta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kartas",
                c => new
                {
                    IdKarte = c.Int(nullable: false, identity: true),
                    VremeKupovine = c.DateTime(nullable: false),
                    Putnik_KorisnickoIme = c.String(maxLength: 128),
                    Stavka_IdStavke = c.Int(),
                    VrstaKarte_Tip = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.IdKarte)
                .ForeignKey("dbo.Putniks", t => t.Putnik_KorisnickoIme)
                .ForeignKey("dbo.Stavkas", t => t.Stavka_IdStavke)
                .ForeignKey("dbo.TipKartes", t => t.VrstaKarte_Tip)
                .Index(t => t.Putnik_KorisnickoIme)
                .Index(t => t.Stavka_IdStavke)
                .Index(t => t.VrstaKarte_Tip);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kartas", "VrstaKarte_Tip", "dbo.TipKartes");
            DropForeignKey("dbo.Kartas", "Stavka_IdStavke", "dbo.Stavkas");
            DropForeignKey("dbo.Kartas", "Putnik_KorisnickoIme", "dbo.Putniks");
            DropIndex("dbo.Kartas", new[] { "VrstaKarte_Tip" });
            DropIndex("dbo.Kartas", new[] { "Stavka_IdStavke" });
            DropIndex("dbo.Kartas", new[] { "Putnik_KorisnickoIme" });
            DropTable("dbo.Kartas");
        }
    }
}
