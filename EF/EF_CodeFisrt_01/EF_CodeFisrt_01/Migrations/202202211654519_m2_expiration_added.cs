namespace EF_CodeFisrt_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2_expiration_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Expiration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Expiration");
        }
    }
}
