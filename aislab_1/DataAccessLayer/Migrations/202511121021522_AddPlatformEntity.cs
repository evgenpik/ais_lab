namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatformEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        GameGenre = c.Int(nullable: false),
                        Developer = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        PlatformId = c.Guid(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Platforms", t => t.PlatformId, cascadeDelete: true)
                .Index(t => t.PlatformId);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropIndex("dbo.Games", new[] { "PlatformId" });
            DropTable("dbo.Platforms");
            DropTable("dbo.Games");
        }
    }
}
