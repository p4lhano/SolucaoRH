using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //lista de classes que deverão se tornar tabelas no banco
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Funcionario>()
                .HasOne(p => p.Setor)
                .WithMany(b => b.Funcionarios)
                .HasForeignKey(x => x.SetorId)
                .IsRequired();
        }
    }
}