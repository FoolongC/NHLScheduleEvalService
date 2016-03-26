namespace NHLScheduleEvalSvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.B2BComparison",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        GameOneDate = c.DateTime(nullable: false),
                        GameTwoDate = c.DateTime(nullable: false),
                        GameOneHome = c.Boolean(nullable: false),
                        GameTwoHome = c.Boolean(nullable: false),
                        GameOneFinal = c.String(),
                        GameTwoFinal = c.String(),
                        OppPlayedDayBefore = c.Boolean(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.B2BComparison", "TeamId", "dbo.Teams");
            DropIndex("dbo.B2BComparison", new[] { "TeamId" });
            DropTable("dbo.Teams");
            DropTable("dbo.B2BComparison");
        }
    }
}
