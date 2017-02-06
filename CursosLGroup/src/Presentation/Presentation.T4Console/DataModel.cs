
using System;
   
  namespace VentoNorte
  {
          public class Aluno     
        { 
                public virtual int Id { get; set;}
                public virtual string Nome { get; set;}
                public virtual DateTime DataCriacao { get; set;}
          }
        
          public class CursoEntities     
        { 
                public virtual int Id { get; set;}
                public virtual string Descricao { get; set;}
                public virtual string Nome { get; set;}
                public virtual string Autor { get; set;}
                public virtual DateTime DataCriacao { get; set;}
                public virtual int CategoriaId { get; set;}
          }
        
          public class Matricula     
        { 
                public virtual int Id { get; set;}
                public virtual int IdCurso { get; set;}
                public virtual int IdAluno { get; set;}
                public virtual string Observacao { get; set;}
          }
        
          public class AlunoCurso     
        { 
                public virtual int IdAluno { get; set;}
                public virtual int IdCurso { get; set;}
          }
        
          public class __MigrationHistory     
        { 
                public virtual string MigrationId { get; set;}
                public virtual string ContextKey { get; set;}
                public virtual string Model { get; set;}
                public virtual string ProductVersion { get; set;}
          }
        
          public class Categoria     
        { 
                public virtual int Id { get; set;}
                public virtual string Nome { get; set;}
          }
        
          public class AspNetRoles     
        { 
                public virtual string Id { get; set;}
                public virtual string Name { get; set;}
          }
        
          public class AspNetUserRoles     
        { 
                public virtual string UserId { get; set;}
                public virtual string RoleId { get; set;}
          }
        
          public class AspNetUsers     
        { 
                public virtual string Id { get; set;}
                public virtual string Cpf { get; set;}
                public virtual bool Ativo { get; set;}
                public virtual string Email { get; set;}
                public virtual bool EmailConfirmed { get; set;}
                public virtual string PasswordHash { get; set;}
                public virtual string SecurityStamp { get; set;}
                public virtual string PhoneNumber { get; set;}
                public virtual bool PhoneNumberConfirmed { get; set;}
                public virtual bool TwoFactorEnabled { get; set;}
                public virtual DateTime LockoutEndDateUtc { get; set;}
                public virtual bool LockoutEnabled { get; set;}
                public virtual int AccessFailedCount { get; set;}
                public virtual string UserName { get; set;}
          }
        
          public class AspNetUserClaims     
        { 
                public virtual int Id { get; set;}
                public virtual string UserId { get; set;}
                public virtual string ClaimType { get; set;}
                public virtual string ClaimValue { get; set;}
          }
        
          public class AspNetUserLogins     
        { 
                public virtual string LoginProvider { get; set;}
                public virtual string ProviderKey { get; set;}
                public virtual string UserId { get; set;}
          }
        
      
  }