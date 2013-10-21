namespace MVCPicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixShit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropIndex("dbo.Submissions", new[] { "UserId" });
            DropIndex("dbo.Photos", new[] { "UserId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Photos", "UserId");
            CreateIndex("dbo.Submissions", "UserId");
            AddForeignKey("dbo.Photos", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Submissions", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
