using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace ControlePlantas.Data
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {

            builder.ToTable("PLEmpr");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdEmpr")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("NomeEmpr")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Documento)
                .HasColumnName("DocuEmpr")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnName("TeleEmpr")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.CEP)
                .HasColumnType("varchar(8)")
                .HasColumnName("EndeCEP");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Logradouro)
                .HasColumnType("varchar(150)")
                .HasColumnName("EndeLogr")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Numero)
                .HasColumnType("varchar(50)")
                .HasColumnName("EndeNum");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Complemento)
                .HasColumnType("varchar(150)")
                .HasColumnName("EndeCompl");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cidade)
                .HasColumnType("varchar(50)");

            builder.HasMany(x => x.Usuarios)
                   .WithOne(x => x.Empresa)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id);

            builder.MapperDataCadastro();
        }
    }
}
