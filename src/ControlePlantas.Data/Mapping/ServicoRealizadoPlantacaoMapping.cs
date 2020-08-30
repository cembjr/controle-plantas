using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data.Mapping
{
    public class ServicoRealizadoPlantacaoMapping : IEntityTypeConfiguration<ServicoRealizadoPlantacao>
    {
        public void Configure(EntityTypeBuilder<ServicoRealizadoPlantacao> builder)
        {
            builder.ToTable("PLServRealPlan");

            builder.HasKey(x => x.Id);
            /*
                     public Guid IdPlantacao { get; private set; }
                    public EnumTipoServicoRealizado TipoServicoRealizado { get; private set; }
                    public DateTime DataServico { get; private set; }
                    public decimal ValorServico { get; set; }
                    public string Observacao { get; set; }

                    public virtual Plantacao Plantacao { get; set; }
             */
            builder.Property(x => x.TipoServicoRealizado)
                   .HasColumnName("IdTipoServReal")
                   .IsRequired();

            builder.Property(x => x.DataServico)
                   .HasColumnName("DatServ")
                   .IsRequired();

            builder.Property(x => x.ValorServico)
                   .HasColumnName("ValServ")
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
            builder.Property(x => x.Observacao)
                   .HasColumnName("DescObse")
                   .HasColumnType("varchar(2000)");

            builder.MapperDataCadastro();

            builder.HasOne(x => x.Plantacao)
                   .WithMany(x => x.ServicosRealizados)
                   .HasForeignKey(x => x.IdPlantacao)
                   .HasPrincipalKey(x => x.Id)
                   .IsRequired();

            builder.Property(x => x.IdEmpresa)
                   .HasColumnName("IdEmpr")
                   .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.ServicoRealizadoPlantacoes)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
