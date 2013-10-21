namespace MVCPicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoDateTimeOut : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Photos", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
