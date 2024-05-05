using DDD.Domain.BibliotecaContext;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-ELD15QMT;Initial Catalog=TopicosAvancados;Integrated Security=False;User ID=sa;Password=senha;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Disciplinas)
                .WithMany(e => e.Alunos)
                .UsingEntity<Matricula>();

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Livros)
                .WithMany(e => e.Alunos)
                .UsingEntity<Emprestimo>();

            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Bibliotecaria>().ToTable("Bibliotecaria");
            modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pesquisador> Pesquisadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Bibliotecaria> Bibliotecarias { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
