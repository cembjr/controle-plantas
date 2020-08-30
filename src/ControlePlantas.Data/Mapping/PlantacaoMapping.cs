using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data
{
    public class PlantacaoMapping : IEntityTypeConfiguration<Plantacao>
    {
        public void Configure(EntityTypeBuilder<Plantacao> builder)
        {
            builder.ToTable("PLPlan");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdPlan")
                .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasColumnName("DesPlan")
                   .HasColumnType("varchar(150)")
                   .IsRequired();

            builder.Property(x => x.IdAreaPlantio)
                .HasColumnName("IdAreaPlan")
                .IsRequired();

            builder.OwnsOne(x => x.Periodo)
                .Property(x => x.DataInicial)
                .HasColumnName("DatInic")
                .IsRequired();

            builder.OwnsOne(x => x.Periodo)
                .Property(x => x.DataFinal)
                .HasColumnName("DatFina");

            builder.HasOne(x => x.AreaPlantio)
                   .WithMany(x => x.Plantacoes)
                   .HasPrincipalKey(x => x.Id)
                   .HasForeignKey(x => x.IdAreaPlantio);

            builder.Property(x => x.IdEmpresa)
                   .HasColumnName("IdEmpr")
                   .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.Plantacoes)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
