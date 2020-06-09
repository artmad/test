namespace TPT.Migrations
{

    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleCommonTables",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ArticleTitle = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleFirstTypeTable",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ArticleFirstTypeTableProperty = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleCommonTables", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ArticleSecondTypeTable",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ArticleSecondTypeTableProperty = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleCommonTables", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleSecondTypeTable", "Id", "dbo.ArticleCommonTables");
            DropForeignKey("dbo.ArticleFirstTypeTable", "Id", "dbo.ArticleCommonTables");
            DropIndex("dbo.ArticleSecondTypeTable", new[] { "Id" });
            DropIndex("dbo.ArticleFirstTypeTable", new[] { "Id" });
            DropTable("dbo.ArticleSecondTypeTable");
            DropTable("dbo.ArticleFirstTypeTable");
            DropTable("dbo.ArticleCommonTables");
        }
    }
}
