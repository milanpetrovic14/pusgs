namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStanica : DbMigration
    {
        public override void Up()
        {
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
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stanicas", "Linija_IdLinije", "dbo.Linijas");
            DropIndex("dbo.Stanicas", new[] { "Linija_IdLinije" });
            DropTable("dbo.Stanicas");
        }
    }
}
