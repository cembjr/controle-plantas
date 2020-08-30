using ControlePlantas.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlePlantas.Data
{
    public interface IEntityMappingConfiguration
    {
        void Map(ModelBuilder b);
    }

    public interface IEntityMappingConfiguration<T> : IEntityMappingConfiguration where T : Entity<T>
    {
        void Map(EntityTypeBuilder<T> builder);
    }

    public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : Entity<T>
    {
        public abstract void Map(EntityTypeBuilder<T> builder);

        public void Map(ModelBuilder builder)
        {
            Map(builder.Entity<T>());
        }
    }
}
