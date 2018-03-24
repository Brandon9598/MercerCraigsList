namespace Mercer_Craigslist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ImagePath");
        }
    }
}
