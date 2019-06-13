namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Tip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Tip");
        }
    }
}
