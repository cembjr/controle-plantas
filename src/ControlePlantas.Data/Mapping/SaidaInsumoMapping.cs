using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlePlantas.Data
{
    public class SaidaInsumoMapping : IEntityTypeConfiguration<SaidaInsumo>
    {
        public void Configure(EntityTypeBuilder<SaidaInsumo> builder)
        {
            builder.ToTable("PLSaidInsu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdSaidInsu")
                .IsRequired();

            builder.Property(x => x.IdEntradaInsumo)
                .HasColumnName("IdEntrInsu")
                .IsRequired();

            builder.Property(x => x.DataSaida)
                .HasColumnName("DatSaid")
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnName("QtdSaid")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("DescSaid")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.HasOne(x => x.EntradaInsumo)
                   .WithMany(x => x.SaidasInsumo)
                   .HasForeignKey(x => x.IdEntradaInsumo)
                   .HasPrincipalKey(x => x.Id)
                   .IsRequired();

            builder.Property(x => x.IdEmpresa)
                   .HasColumnName("IdEmpr")
                   .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.SaidaInsumos)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
