using ICache.Core.Entities;
using ICache.Core.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ICache.Core.Context
{
    public class ICacheContext : DbContext
    {
        public ICacheContext()
        {
        }

        public ICacheContext(DbContextOptions<ICacheContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        //public DbSet<Conta> Contas { get; set; }
        //public DbSet<Despesas> Despesas { get; set; }
        //public DbSet<Receitas> Receitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(new CategoryMap().Configure);
            //modelBuilder.Entity<Conta>(new ContaMap().Configure);
            //modelBuilder.Entity<Despesas>(new DespesaMap().Configure);
            //modelBuilder.Entity<Receitas>(new ReceitaMap().Configure);
        }
    }
}
