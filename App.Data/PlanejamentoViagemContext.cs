using Microsoft.EntityFrameworkCore;
using PlanejamentoViagem.Classes;

namespace App.Data
{
    public class PlanejamentoViagemContext : DbContext
    {
        public DbSet<Viajante> Viajante { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<LocalInteresse> LocalInteresse { get; set; }
        public DbSet<Roteiro> Roteiro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS14; Database = PlanejamentoViagem; Trusted_Connection = True;");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Viajante>().HasKey(x => x.IdViajante);
            modelBuilder.Entity<Viajante>().HasOne(x => x.Endereco).WithOne(x => x.Viajante).HasForeignKey("Viajante", "IdEndereco");
            modelBuilder.Entity<Endereco>().HasKey(x => x.IdEndereco);
            modelBuilder.Entity<LocalInteresse>().HasKey(x => x.IdLocalInteresse);
            modelBuilder.Entity<LocalInteresse>().HasOne(x => x.Endereco).WithOne(x => x.LocalInteresse).HasForeignKey("LocalInteresse", "IdEndereco");
            modelBuilder.Entity<Roteiro>().HasKey(x => x.IdRoteiro);
            modelBuilder.Entity<Roteiro>().HasOne(x => x.Viajante).WithMany(x => x.Roteiros).HasForeignKey("IdViajante").OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RoteiroLocalInteresse>().HasKey(x => new { x.IdRoteiro, x.IdLocalInteresse });
            modelBuilder.Entity<RoteiroLocalInteresse>().HasOne(x => x.Roteiro).WithMany(x => x.Locais).HasForeignKey("IdRoteiro");
            modelBuilder.Entity<RoteiroLocalInteresse>().HasOne(x => x.LocalInteresse).WithMany(x => x.Roteiros).HasForeignKey("IdLocalInteresse");
        }
    }
}
