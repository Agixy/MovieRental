namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AddColumn("dbo.Movies", "Genere_Id", c => c.Byte());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "Genere_Id");
            AddForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "Genere_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "Genere_Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Generes", "Id", cascadeDelete: true);
        }
    }
}
