namespace MVCPicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAuthenticationStuff : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Submissions", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            CreateIndex("dbo.Submissions", "UserId");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Photos", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String());
            DropIndex("dbo.Submissions", new[] { "UserId" });
            DropForeignKey("dbo.Submissions", "UserId", "dbo.Users");
        }
    }
}
