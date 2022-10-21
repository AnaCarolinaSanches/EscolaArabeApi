using APIEscolaArabe.Models;
using Microsoft.EntityFrameworkCore;

namespace APIEscolaArabe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Aluno> Alunos{get;set;}
        public DbSet<Aula> Aulas{get;set;}
        public DbSet<Endereco> Enderecos{get;set;}
        public DbSet<Modalidade> Modalidades{get;set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}