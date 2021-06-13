using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ICache.Core.Context;
using ICache.Core.Entities;
using ICache.Core.Interfaces.Repositories;
using ICache.Repository.Repositories.Base;

namespace ICache.Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ICacheContext context) : base(context)
        {
        }

        public async Task CreateAsync(Category category)
        {
            bool categoryExists = _context.Category.Any(x => x.Description.Equals(category.Description) && x.Active == true);
            if (categoryExists) throw new Exception($"{"Registro"} {category.Description} {"encontrato, tente novamente!"}");
            await base.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            IEnumerable<Category> categories = await base.ListAsync();
            return categories.OrderBy(x => x.Description).ToList();
        }
    }
}
