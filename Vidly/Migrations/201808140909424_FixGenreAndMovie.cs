namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixGenreAndMovie : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Generes", newName: "Genres");
            DropForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "Genere_Id" });
            DropColumn("dbo.Movies", "GenreId");
            RenameColumn(table: "dbo.Movies", name: "Genere_Id", newName: "GenreId");
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte());
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genere_Id");
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genere_Id");
            AddForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes", "Id");
            RenameTable(name: "dbo.Genres", newName: "Generes");
        }
    }
}
