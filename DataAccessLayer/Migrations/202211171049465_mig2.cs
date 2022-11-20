namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMediaUsers", "SocialMediaUserAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.SocialMediaUsers", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.SocialMediaUsers", "Password", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SocialMediaUsers", "Password", c => c.String(maxLength: 20));
            AlterColumn("dbo.SocialMediaUsers", "Email", c => c.String(maxLength: 50));
            DropColumn("dbo.SocialMediaUsers", "SocialMediaUserAbout");
        }
    }
}
