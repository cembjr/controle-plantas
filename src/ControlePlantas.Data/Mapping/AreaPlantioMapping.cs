using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data
{
    public class AreaPlantioMapping : IEntityTypeConfiguration<AreaPlantio>
    {
        public void Configure(EntityTypeBuilder<AreaPlantio> builder)
        {
            builder.ToTable("PLArePlan");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdAreaPlan")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("DescAreaPlan")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.TamanhoAlqueires)
                .HasColumnName("ValTamaAlqu")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TamanhoHectares)
                .HasColumnName("ValTamaHect")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasMany(x => x.Plantacoes)
                   .WithOne(x => x.AreaPlantio)
                   .HasForeignKey(x => x.IdAreaPlantio)
                   .HasPrincipalKey(x => x.Id);

            builder.Property(x => x.IdEmpresa)
                   .HasColumnName("IdEmpr")
                   .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.AreasPlantio)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
