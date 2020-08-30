using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data.Mapping
{
    public class UtilizacaoInsumoItemMapping : IEntityTypeConfiguration<UtilizacaoInsumoItem>
    {
        public void Configure(EntityTypeBuilder<UtilizacaoInsumoItem> builder)
        {
            builder.ToTable("PLUtilInsuItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdUtilInsuItem")
                .IsRequired();

            builder.Property(x => x.IdUtilizacaoInsumo)
                   .HasColumnName("IdUtilInsu")
                   .IsRequired();

            builder.Property(x => x.IdEntradaInsumo)
                   .HasColumnName("IdEntrInsu")
                   .IsRequired();

            builder.Property(x => x.Quantidade)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasOne(x => x.UtilizacaoInsumo)
                   .WithMany(x => x.ItensUtilizacao)
                   .HasForeignKey(x => x.IdUtilizacaoInsumo)
                   .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.EntradaInsumo)
                   .WithMany(x => x.UtilizacaoInsumoItens)
                   .HasForeignKey(x => x.IdEntradaInsumo)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
