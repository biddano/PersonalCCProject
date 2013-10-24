namespace MVCPicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedStuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "SubmissionId", "dbo.Submissions");
            DropIndex("dbo.Photos", new[] { "SubmissionId" });
            AddColumn("dbo.Submissions", "Photo_PhotoId", c => c.Int());
            AddColumn("dbo.Photos", "UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Submissions", "Photo_PhotoId", "dbo.Photos", "PhotoId");
            AddForeignKey("dbo.Photos", "UserId", "dbo.Users", "UserId", cascadeDelete: false);
            CreateIndex("dbo.Submissions", "Photo_PhotoId");
            CreateIndex("dbo.Photos", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropIndex("dbo.Submissions", new[] { "Photo_PhotoId" });
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Submissions", "Photo_PhotoId", "dbo.Photos");
            DropColumn("dbo.Photos", "UserId");
            DropColumn("dbo.Submissions", "Photo_PhotoId");
            CreateIndex("dbo.Photos", "SubmissionId");
            AddForeignKey("dbo.Photos", "SubmissionId", "dbo.Submissions", "SubmissionId", cascadeDelete: false);
        }
    }
}
