namespace MVCPicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhotoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        SubmissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: true)
                .Index(t => t.SubmissionId);
            
            DropColumn("dbo.Submissions", "PhotoURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "PhotoURL", c => c.String());
            DropIndex("dbo.Photos", new[] { "SubmissionId" });
            DropForeignKey("dbo.Photos", "SubmissionId", "dbo.Submissions");
            DropTable("dbo.Photos");
        }
    }
}
