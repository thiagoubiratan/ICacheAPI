using ICache.Core.Entities.Base;
using ICache.Core.Enum;
using System.Collections.Generic;

namespace ICache.Core.Entities
{
    public class Conta : BaseEntity
    {
        public Conta()
        {
            Despesas = new HashSet<Despesas>();
            Receitas = new HashSet<Receitas>();
        }

        public string Descricao { get; set; }
        public TipoContaEnum TipoConta { get;set; }

        public virtual ICollection<Despesas> Despesas { get; set; }
        public virtual ICollection<Receitas> Receitas { get; set; }
    }
}
