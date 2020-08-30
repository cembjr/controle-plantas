using ControlePlantas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlePlantas.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("PLUsua");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdUsua")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("NomUsua")
                .IsRequired();

            builder.Property(x => x.TipoUsuario)
                .HasColumnType("int")
                .HasColumnName("TipoUsua")
                .IsRequired();

            builder.Property(x => x.Login)
                .HasColumnName("LogiUsua")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("SenhUsua")
                .IsRequired();
            
            builder.Property(x => x.IdEmpresa)
                .HasColumnName("IdEmpr")
                .IsRequired();

            builder.HasOne(x => x.Empresa)
                   .WithMany(x => x.Usuarios)
                   .HasForeignKey(x => x.IdEmpresa)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.MapperDataCadastro();
        }
    }
}
