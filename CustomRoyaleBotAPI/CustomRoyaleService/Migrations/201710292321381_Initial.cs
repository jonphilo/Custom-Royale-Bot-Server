namespace CustomRoyaleService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModes",
                c => new
                    {
                        GameModeId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 256),
                        Submitter = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.GameModeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameModes");
        }
    }
}
