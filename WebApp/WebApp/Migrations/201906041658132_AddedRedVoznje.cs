namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRedVoznje : DbMigration
    {
        public override void Up()
        {
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
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RedVoznjes", "Linije_IdLinije", "dbo.Linijas");
            DropIndex("dbo.RedVoznjes", new[] { "Linije_IdLinije" });
            DropTable("dbo.RedVoznjes");
        }
    }
}
