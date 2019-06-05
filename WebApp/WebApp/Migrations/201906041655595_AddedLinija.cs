namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLinija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Linijas",
                c => new
                {
                    IdLinije = c.Int(nullable: false, identity: true),
                    ImeLinije = c.String(),
                })
                .PrimaryKey(t => t.IdLinije);
        }
        
        public override void Down()
        {
            DropTable("dbo.Linijas");
        }
    }
}
