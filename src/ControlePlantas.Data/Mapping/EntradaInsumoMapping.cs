using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data
{
    public class EntradaInsumoMapping : IEntityTypeConfiguration<EntradaInsumo>
    {
        public void Configure(EntityTypeBuilder<EntradaInsumo> builder)
        {
            builder.ToTable("PLEntrInsu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdEntrInsu")
                .IsRequired();

            builder.Property(x => x.IdInsumo)
                .HasColumnName("IdInsu")
                .IsRequired();

            builder.Property(x => x.DataEntrada)
                .HasColumnName("DatEntr")
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnName("QtdEntr")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.ValorUnitario)
                .HasColumnName("ValEntr")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.IdFornecedor)
                .HasColumnName("IdForn")
                .IsRequired();

            builder.Property(x => x.Documento)
                .HasColumnName("DescDocu")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.HasOne(x => x.Insumo)
                   .WithMany(x => x.EntradasInsumo)
                   .HasForeignKey(x => x.IdInsumo)
                   .HasPrincipalKey(x => x.Id)
                   .IsRequired();

            builder.HasOne(x => x.Fornecedor)
                .WithMany(x => x.EntradasInsumos)
                .HasForeignKey(x => x.IdFornecedor)
                .HasPrincipalKey(x => x.Id);

            builder.Property(x => x.IdEmpresa)
                   .HasColumnName("IdEmpr")
                   .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.EntradaInsumos)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
