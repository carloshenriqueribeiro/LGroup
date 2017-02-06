using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 //Estamos importando o Domain
using Domain.GerenciamentoCursosLGroup;
using Domain.GerenciamentoCursosLGroup.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.EF.Context
{
    //Esta classe será o nosso banco (context)
    //Quando usamos entityFramework precisamos herdar de DbContext
    //Porém para usar o Aspnet Identity precisamos herdar de IdentityDbContext
    public class GerenciamentoCursoLGroupContext
        : IdentityDbContext<UsuarioEntity>
    {
        public GerenciamentoCursoLGroupContext()
            : base("CursoLGroup")//Nome da string de conexão que esta no web config da ui
        {}

        //Para habitar usar migration temos que digitar
        //Enable-migrations
        
        //Para criar um script de banco
        //add-migration {nome}

        //Para salvar os dados no banco
        //update-database

        //Precimos definiar as tabelas
        public DbSet<CursoEntity> Curso { get; set; }
        public DbSet<AlunoEntity> Aluno { get; set; }
        public DbSet<MatriculaEntity> Matricula { get; set; }
        
        //Vai ser uma tabela
        public DbSet<CategoriaEntity> Categoria { get; set; }

        //Este método é responsavel pela criação do nosso modelo
        //no banco de dados
        //Vamos colocar algumas coisas além do que ele ja faz
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adicionar alguns itens a mais que o padrão
            //Vamos renomear a tabela associativa (aquela gerada da relação nxn)

            modelBuilder.Entity<AlunoEntity>()
                .HasMany(x => x.Cursos)
                .WithMany(x => x.Alunos)
                .Map(x =>
                {
                    x.MapLeftKey("IdAluno");
                    x.MapRightKey("IdCurso");
                    x.ToTable("AlunoCurso");
                });

            //É o que ele já faz por padrão (o que a classe pai já faz!!!)
            base.OnModelCreating(modelBuilder);
        }
    }
}
