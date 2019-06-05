namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPutnik : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Putniks",
                c => new
                {
                    KorisnickoIme = c.String(nullable: false, maxLength: 128),
                    DatumRodjenja = c.DateTime(nullable: false),
                    Dokument = c.String(),
                    Email = c.String(),
                    Ime = c.String(),
                    Prezime = c.String(),
                    Tip_Tip = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.KorisnickoIme)
                .ForeignKey("dbo.TipPutnikas", t => t.Tip_Tip)
                .Index(t => t.Tip_Tip);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Putniks", "Tip_Tip", "dbo.TipPutnikas");
            DropIndex("dbo.Putniks", new[] { "Tip_Tip" });
            DropTable("dbo.Putniks");
        }
    }
}
