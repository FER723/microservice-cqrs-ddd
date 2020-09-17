using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioPrueba.Infrastructure.Domain.Atributo
{
    class AtributoEntityTypeConfiguration : IEntityTypeConfiguration<AtributoEntity>
    {
        void IEntityTypeConfiguration<AtributoEntity>.Configure(EntityTypeBuilder<AtributoEntity> builder)
        {
            builder.ToTable("clips_atributos");
            builder.HasKey(b => b.atributoId);
            builder.Property(p => p.atributoId).HasColumnName("idAtributo");
            builder.Property(p => p.descripcion).HasColumnName("vchAtributo");
        }
    }
}
