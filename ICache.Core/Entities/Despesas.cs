using ICache.Core.Entities.Base;
using System;

namespace ICache.Core.Entities
{
    public class Despesas : BaseEntity
    {
        public string Descricao { get; set; }
        public long CategoriaId { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public bool Efetivada { get; set; }
        public long ContaId { get; set; }

        public virtual Category Categoria { get; set; }
        public virtual Conta Conta { get; set; }

    }
}
