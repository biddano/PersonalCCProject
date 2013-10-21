namespace MVCPicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Users", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Comments", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Comments", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Submissions", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Submissions", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Submissions", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
