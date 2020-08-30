using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Data
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("PLForn");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdForn")
                .IsRequired();

            builder.Property(x => x.Nome)
                   .HasColumnName("NomForn")
                   .HasColumnType("varchar(150)")
                   .IsRequired();

            builder.Property(x => x.Documento)
                .HasColumnName("DocuForn")
                .HasColumnType("varchar(50)");

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
                .HasColumnType("varchar(50)")
                .HasColumnName("EndeCida");

            builder.HasMany(x => x.EntradasInsumos)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.IdFornecedor)
                .HasPrincipalKey(x => x.Id);

            builder.Property(x => x.IdEmpresa)
               .HasColumnName("IdEmpr")
               .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.Fornecedores)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.MapperDataCadastro();
        }
    }
}
