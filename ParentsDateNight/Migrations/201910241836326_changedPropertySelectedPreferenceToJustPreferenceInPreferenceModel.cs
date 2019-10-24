namespace ParentsDateNight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedPropertySelectedPreferenceToJustPreferenceInPreferenceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "Preferences", c => c.String());
            DropColumn("dbo.Preferences", "selectedPreference");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "selectedPreference", c => c.String());
            DropColumn("dbo.Preferences", "Preferences");
        }
    }
}
