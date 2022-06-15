namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogTable : DbMigration
    {
        public override void Up()
        {
          
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        LoginTime = c.String(),
                        LogoutTime = c.String(),
                        TimeSpent = c.Int(nullable: false),
                        Reason = c.String(),
                        IsCrash = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
            
        }
    }
}
