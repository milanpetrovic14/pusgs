namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cenovniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Od = c.DateTime(nullable: false),
                        Do = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        IdKarte = c.Int(nullable: false, identity: true),
                        VremeKupovine = c.DateTime(nullable: false),
                        Stavka_IdStavke = c.Int(),
                        VrstaKarte_Tip = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdKarte)
                .ForeignKey("dbo.Stavkas", t => t.Stavka_IdStavke)
                .ForeignKey("dbo.TipKartes", t => t.VrstaKarte_Tip)
                .Index(t => t.Stavka_IdStavke)
                .Index(t => t.VrstaKarte_Tip);
            
            CreateTable(
                "dbo.Linijas",
                c => new
                    {
                        IdLinije = c.Int(nullable: false, identity: true),
                        ImeLinije = c.String(),
                    })
                .PrimaryKey(t => t.IdLinije);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        IdStanice = c.Int(nullable: false, identity: true),
                        AdresaStanice = c.String(),
                        NazivStanice = c.String(),
                        Linija_IdLinije = c.Int(),
                    })
                .PrimaryKey(t => t.IdStanice)
                .ForeignKey("dbo.Linijas", t => t.Linija_IdLinije)
                .Index(t => t.Linija_IdLinije);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RedVoznjes",
                c => new
                    {
                        IdRedaVoznje = c.Int(nullable: false, identity: true),
                        Dan = c.Int(nullable: false),
                        Linije_IdLinije = c.Int(),
                    })
                .PrimaryKey(t => t.IdRedaVoznje)
                .ForeignKey("dbo.Linijas", t => t.Linije_IdLinije)
                .Index(t => t.Linije_IdLinije);
            
            CreateTable(
                "dbo.TipPutnikas",
                c => new
                    {
                        Tip = c.String(nullable: false, maxLength: 128),
                        Koeficijet = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Tip);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.AspNetUsers", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RedVoznjes", "Linije_IdLinije", "dbo.Linijas");
            DropForeignKey("dbo.Stanicas", "Linija_IdLinije", "dbo.Linijas");
            DropForeignKey("dbo.Kartas", "VrstaKarte_Tip", "dbo.TipKartes");
            DropForeignKey("dbo.Kartas", "Stavka_IdStavke", "dbo.Stavkas");
            DropForeignKey("dbo.Stavkas", "TipKarte_Tip", "dbo.TipKartes");
            DropForeignKey("dbo.TipKartes", "Stavka_IdStavke", "dbo.Stavkas");
            DropForeignKey("dbo.Stavkas", "Cenovnik_Id", "dbo.Cenovniks");
            DropIndex("dbo.RedVoznjes", new[] { "Linije_IdLinije" });
            DropIndex("dbo.Stanicas", new[] { "Linija_IdLinije" });
            DropIndex("dbo.Kartas", new[] { "VrstaKarte_Tip" });
            DropIndex("dbo.Kartas", new[] { "Stavka_IdStavke" });
            DropIndex("dbo.TipKartes", new[] { "Stavka_IdStavke" });
            DropIndex("dbo.Stavkas", new[] { "TipKarte_Tip" });
            DropIndex("dbo.Stavkas", new[] { "Cenovnik_Id" });
            DropColumn("dbo.AspNetUsers", "Date");
            DropColumn("dbo.AspNetUsers", "ConfirmPassword");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.TipPutnikas");
            DropTable("dbo.RedVoznjes");
            DropTable("dbo.Products");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Linijas");
            DropTable("dbo.Kartas");
            DropTable("dbo.TipKartes");
            DropTable("dbo.Stavkas");
            DropTable("dbo.Cenovniks");
        }
    }
}
