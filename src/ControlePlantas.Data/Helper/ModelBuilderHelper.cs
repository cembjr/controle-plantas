using ControlePlantas.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ControlePlantas.Data
{
    public static class ModelBuilderHelper
    {       
        public static void MapperDataCadastro<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity<TEntity>
        {
            builder.Property(x => x.DataCadastro)
                   .HasColumnName("DatCada")
                   .IsRequired();
        }
    }
}
