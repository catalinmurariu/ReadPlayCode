namespace ReadPlayCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTextToBlogPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserRole_Id", "dbo.Roles");
            DropForeignKey("dbo.BlogPosts", "Author_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "UserRole_Id" });
            DropIndex("dbo.BlogPosts", new[] { "Author_Id" });
            CreateTable(
                "dbo.BlogPostEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Updated = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        Created = c.DateTime(nullable: false),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleEntities", t => t.UserRole_Id)
                .Index(t => t.UserRole_Id);
            
            CreateTable(
                "dbo.RoleEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        Created = c.DateTime(nullable: false),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Updated = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.BlogPostEntities", "Author_Id", "dbo.UserEntities");
            DropForeignKey("dbo.UserEntities", "UserRole_Id", "dbo.RoleEntities");
            DropIndex("dbo.BlogPostEntities", new[] { "Author_Id" });
            DropIndex("dbo.UserEntities", new[] { "UserRole_Id" });
            DropTable("dbo.RoleEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.BlogPostEntities");
            CreateIndex("dbo.BlogPosts", "Author_Id");
            CreateIndex("dbo.Users", "UserRole_Id");
            AddForeignKey("dbo.BlogPosts", "Author_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "UserRole_Id", "dbo.Roles", "Id");
        }
    }
}
