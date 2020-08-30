using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data
{
    public class InsumosMapping : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("PLInsu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdInsu")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("NomInsu")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.TipoInsumo)
                .HasColumnName("IdTipoInsu")
                .IsRequired();

            builder.HasMany(x => x.EntradasInsumo)
                   .WithOne(x => x.Insumo)
                   .HasForeignKey(x => x.IdInsumo)
                   .HasPrincipalKey(x => x.Id)
                   .IsRequired();
           
            builder.Property(x => x.IdEmpresa)
                   .HasColumnName("IdEmpr")
                   .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.Insumos)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
