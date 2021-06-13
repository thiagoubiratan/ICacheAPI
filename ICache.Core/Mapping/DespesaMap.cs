using ICache.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICache.Core.Mapping
{
    public class DespesaMap : IEntityTypeConfiguration<Despesas>
    {
        public void Configure(EntityTypeBuilder<Despesas> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.CategoriaId)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.DataPagamento)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.Efetivada)
                .IsRequired();

            builder.Property(x => x.ContaId)
                .IsRequired();

            //builder.HasOne(x => x.Categoria)
            //    .WithMany(x => x.Despesas)
            //    .HasForeignKey(y => y.CategoriaId);

            builder.HasOne(x => x.Conta)
                .WithMany(x => x.Despesas)
                .HasForeignKey(y => y.ContaId);
        }
    }
}

