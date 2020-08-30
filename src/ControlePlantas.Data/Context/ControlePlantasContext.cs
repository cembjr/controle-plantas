using ControlePlantas.Domain;
using ControlePlantas.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Data
{
    public class ControlePlantasContext : DbContext, IUnitOfWork
    {
        public DbSet<AreaPlantio> AreasPlantios { get; set; }

        public DbSet<Plantacao> Plantacoes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EntradaInsumo> EntradaInsumos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<ServicoRealizadoPlantacao> ServicoRealizadoPlantacoes { get; set; }
        public DbSet<UtilizacaoInsumo> UtilizacaoInsumos { get; set; }
        public DbSet<UtilizacaoInsumoItem> UtilizacaoInsumoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // setando tipos string para tamanho varchar 100
            foreach (var propriedade in modelBuilder.Model.GetEntityTypes().SelectMany(m => m.GetProperties().Where(w => w.ClrType == typeof(string))))
                propriedade.SetColumnType("varchar(100)");

            // removendo delete cascade
            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes().SelectMany(m => m.GetForeignKeys()))
                relacionamento.DeleteBehavior = DeleteBehavior.ClientSetNull;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            var conectionString = config.GetConnectionString("Database");
            optionsBuilder.UseSqlServer(conectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public async Task<bool> Commit()
        {
            SetarDataCadastro();
            var ret = await base.SaveChangesAsync() > 0;
            return ret;
        }

        private void SetarDataCadastro()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }
        }
    }
}
