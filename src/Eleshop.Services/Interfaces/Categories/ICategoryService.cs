using Eleshop.Application.Utilities;
using Eleshop.Domain.Entites.Categories;
using Eleshop.Persistance.Dtos.Categories;

namespace Eleshop.Services.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);

    public Task<Category> GetByIdAsync(long cateogoryId);

    public Task<bool> UpdateAsync(long cateogoryId, CategoryUpdateDto dto);
}
