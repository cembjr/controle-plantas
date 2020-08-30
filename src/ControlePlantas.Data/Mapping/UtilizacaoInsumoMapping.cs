using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data
{
    public class UtilizacaoInsumoItemMapping : IEntityTypeConfiguration<UtilizacaoInsumo>
    {
        public void Configure(EntityTypeBuilder<UtilizacaoInsumo> builder)
        {
            builder.ToTable("PLUtilInsu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdUtilInsu")
                .IsRequired();

            builder.Property(x => x.IdPlantacao)
                   .HasColumnName("IdPlan")
                   .IsRequired();
            
            builder.Property(x => x.DataUtilizacao)
                   .HasColumnName("DatUtil")
                   .IsRequired();


            builder.Property(x => x.Observacao)
                   .HasColumnName("ObsUtilInsu")
                   .HasColumnType("varchar(200)");

            builder.HasMany(x => x.ItensUtilizacao)
                   .WithOne(x => x.UtilizacaoInsumo)
                   .HasForeignKey(x => x.IdUtilizacaoInsumo)
                   .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.Plantacao)
                   .WithMany(x => x.InsumosUtilizado)
                   .HasForeignKey(x => x.IdPlantacao)
                   .HasPrincipalKey(x => x.Id);

            builder.Property(x => x.IdEmpresa)
                   .HasColumnName("IdEmpr")
                   .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.UtilizacaoInsumos)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
