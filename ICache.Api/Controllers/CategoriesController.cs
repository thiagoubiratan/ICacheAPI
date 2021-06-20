using ICache.Api.Controllers.Base;
using ICache.Api.Helpers;
using ICache.Api.Utils;
using ICache.Core.Entities;
using ICache.Core.Interfaces.Repositories;
using ICache.Core.Interfaces.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ICache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _uow;

        public CategoriesController(ICategoryRepository categoryRepository, IUnitOfWork uow)
        {
            _categoryRepository = categoryRepository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<PageList<Category>>> GetCategorias()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(new ApiOkResponse(categories));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoria(long id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);
            return Ok(category == null ? new ApiResponse(404, $"{ITEM_NOT_FOUND}") : new ApiOkResponse(category));
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategoria(Category category)
        {
            await _categoryRepository.CreateAsync(category);
            await _uow.Commit();
            return Ok(new ApiOkResponse(category));
        }

        [HttpPut()]
        public async Task<IActionResult> PutCategoriaAsync(Category category)
        {
            //if (await _categoryRepository.FindByIdAsync(category.Id) == null) return NotFound(new ApiResponse(404, $"{ITEM_NOT_FOUND}"));
            _categoryRepository.Update(category);
            await _uow.Commit();
            return Ok(new ApiOkResponse(category));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategoria(long id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);
            if (category == null) return NotFound(new ApiResponse(404, $"{ITEM_NOT_FOUND}"));
            _categoryRepository.Remove(category);
            await _uow.Commit();
            return category;
        }
    }
}
