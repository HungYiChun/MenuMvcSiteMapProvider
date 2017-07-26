namespace MenuMvcSiteMapProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMenuDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 128),
                        Role = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(nullable: false, maxLength: 128),
                        Area = c.String(maxLength: 128),
                        Controller = c.String(maxLength: 128),
                        Action = c.String(maxLength: 128),
                        Url = c.String(maxLength: 128),
                        ParentMenuId = c.Int(),
                        State = c.Int(),
                        RouteValues = c.String(maxLength: 128),
                        OrderSerial = c.Int(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menu");
            DropTable("dbo.Account");
        }
    }
}
