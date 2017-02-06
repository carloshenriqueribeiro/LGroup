namespace Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CursoEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Nome = c.String(),
                        Autor = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCurso = c.Int(nullable: false),
                        IdAluno = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aluno", t => t.IdAluno, cascadeDelete: true)
                .ForeignKey("dbo.CursoEntities", t => t.IdCurso, cascadeDelete: true)
                .Index(t => t.IdCurso)
                .Index(t => t.IdAluno);
            
            CreateTable(
                "dbo.AlunoCurso",
                c => new
                    {
                        IdAluno = c.Int(nullable: false),
                        IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdAluno, t.IdCurso })
                .ForeignKey("dbo.Aluno", t => t.IdAluno, cascadeDelete: true)
                .ForeignKey("dbo.CursoEntities", t => t.IdCurso, cascadeDelete: true)
                .Index(t => t.IdAluno)
                .Index(t => t.IdCurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "IdCurso", "dbo.CursoEntities");
            DropForeignKey("dbo.Matricula", "IdAluno", "dbo.Aluno");
            DropForeignKey("dbo.AlunoCurso", "IdCurso", "dbo.CursoEntities");
            DropForeignKey("dbo.AlunoCurso", "IdAluno", "dbo.Aluno");
            DropIndex("dbo.AlunoCurso", new[] { "IdCurso" });
            DropIndex("dbo.AlunoCurso", new[] { "IdAluno" });
            DropIndex("dbo.Matricula", new[] { "IdAluno" });
            DropIndex("dbo.Matricula", new[] { "IdCurso" });
            DropTable("dbo.AlunoCurso");
            DropTable("dbo.Matricula");
            DropTable("dbo.CursoEntities");
            DropTable("dbo.Aluno");
        }
    }
}
