using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using WebApplication1.Data.Map;
using WebApplication1.Models;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<FornecedorModel> Fornecedor { get; set;}
        public DbSet<AlimentoModel> Alimentos { get; set; }
        public DbSet<LogsModel> Logs { get; set; }
        public DbSet<FornecimentosModel> Fornecimentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new LogsMap());
            modelBuilder.ApplyConfiguration(new FornecimentosMap());

            // Configuração de exclusão em cascata para Fornecedores
            modelBuilder.Entity<FornecimentosModel>()
           .HasOne(f => f.Fornecedor)
           .WithMany(f => f.fornecimento)
           .HasForeignKey(f => f.IdFornecedor)
           .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata já configurada
         
            // Configuração de exclusão em cascata para Alimentos
            modelBuilder.Entity<FornecimentosModel>()
            .HasOne(f => f.Alimento)
            .WithMany(a => a.fornecimento)
            .HasForeignKey(f => f.IdAlimento)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LogsModel>()
            .HasOne(l => l.Alimento)
            .WithMany(a => a.logs)
            .HasForeignKey(l => l.IdAlimento)
            .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}