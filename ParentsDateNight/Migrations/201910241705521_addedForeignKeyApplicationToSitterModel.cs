namespace ParentsDateNight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKeyApplicationToSitterModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sitters", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sitters", "ApplicationId");
            AddForeignKey("dbo.Sitters", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sitters", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Sitters", new[] { "ApplicationId" });
            DropColumn("dbo.Sitters", "ApplicationId");
        }
    }
}
