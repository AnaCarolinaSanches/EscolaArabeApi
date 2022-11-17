using APIEscolaArabe.Models;
using EscolaArabeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace APIEscolaArabe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }

        public DbSet<AlunoModalidade> AlunoModalidades { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoModalidade>()
                .HasKey(AD => new { AD.AlunoId, AD.ModalidadeId });
            builder.Entity<ModalidadeAula>()
                .HasKey(AD => new { AD.AulaId, AD.ModalidadeId });
        }
    }
}