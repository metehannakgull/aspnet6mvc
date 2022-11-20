namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "SocialMediaUserId", c => c.Int());
            CreateIndex("dbo.Contents", "SocialMediaUserId");
            AddForeignKey("dbo.Contents", "SocialMediaUserId", "dbo.SocialMediaUsers", "SocialMediaUserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "SocialMediaUserId", "dbo.SocialMediaUsers");
            DropIndex("dbo.Contents", new[] { "SocialMediaUserId" });
            DropColumn("dbo.Contents", "SocialMediaUserId");
        }
    }
}
