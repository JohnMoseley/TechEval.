namespace Heuristics.TechEval.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "CategoryId", c => c.Int());
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Member", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Member", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Category", "Name", unique: true, name: "Name");
            CreateIndex("dbo.Member", "Name", unique: true, name: "Name");
            CreateIndex("dbo.Member", "CategoryId");
            AddForeignKey("dbo.Member", "CategoryId", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "CategoryId", "dbo.Category");
            DropIndex("dbo.Member", new[] { "CategoryId" });
            DropIndex("dbo.Member", "Name");
            DropIndex("dbo.Category", "Name");
            AlterColumn("dbo.Member", "Email", c => c.String());
            AlterColumn("dbo.Member", "Name", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String());
            DropColumn("dbo.Member", "CategoryId");
        }
    }
}
