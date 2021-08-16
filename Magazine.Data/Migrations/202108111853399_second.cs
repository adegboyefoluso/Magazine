namespace Magazine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "EventHightlight", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "EventHightlight");
        }
    }
}
