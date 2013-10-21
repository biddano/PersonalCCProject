namespace MVCPicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        UserId = c.Int(nullable: false),
                        SubmissionId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.SubmissionId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        PhotoURL = c.String(),
                        UserId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Submissions", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "SubmissionId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropForeignKey("dbo.Submissions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropTable("dbo.Submissions");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
        }
    }
}
