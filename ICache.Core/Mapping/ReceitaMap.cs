using ICache.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICache.Core.Mapping
{
    public class ReceitaMap : IEntityTypeConfiguration<Receitas>
    {
        public void Configure(EntityTypeBuilder<Receitas> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.DataRecebimento)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.HasOne(x => x.Conta)
                .WithMany(x => x.Receitas)
                .HasForeignKey(y => y.ContaId);
        }
    }
}
