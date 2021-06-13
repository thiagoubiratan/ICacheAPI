using ICache.Core.Entities.Base;
using System;

namespace ICache.Core.Entities
{
    public class Receitas : BaseEntity
    {
        public string Descricao { get; set; }
        public DateTime DataRecebimento { get; set; }
        public decimal Valor { get; set; }
        public long ContaId { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
