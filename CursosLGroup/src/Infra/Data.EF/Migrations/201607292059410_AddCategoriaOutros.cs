namespace Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaOutros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CursoEntities", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.CursoEntities", "CategoriaId");
            AddForeignKey("dbo.CursoEntities", "CategoriaId", "dbo.Categoria", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CursoEntities", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.CursoEntities", new[] { "CategoriaId" });
            DropColumn("dbo.CursoEntities", "CategoriaId");
            DropTable("dbo.Categoria");
        }
    }
}
