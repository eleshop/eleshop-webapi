using AutoMapper;
using Eleshop.Application.Exceptions.Categories;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Categories;
using Eleshop.Domain.Entites.Categories;
using Eleshop.Persistance.Dtos.Categories;
using Eleshop.Persistance.Helpers;
using Eleshop.Services.Interfaces.Categories;
using Eleshop.Services.Interfaces.Common;

namespace Eleshop.Services.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepasitory _repository;
    private readonly IPaginator _paginator;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepasitory categoryRepository,
        IPaginator paginator,
        IMapper mapper)
    {
        this._repository = categoryRepository;
        this._paginator = paginator;
        this._mapper = mapper;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        Category category = _mapper.Map<Category>(dto);
        category.CreatedAt = category.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(category);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category == null) throw new CategoryNotFoundException();

        var dbResult = await _repository.DeleteAsync(categoryId);

        return dbResult > 0;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return categories;
    }

    public async Task<Category> GetByIdAsync(long cateogoryId)
    {
        var category = await _repository.GetByIdAsync(cateogoryId);
        if (category is null) throw new CategoryNotFoundException();
        else return category;
    }

    public async Task<bool> UpdateAsync(long cateogoryId, CategoryUpdateDto dto)
    {
        var category = await _repository.GetByIdAsync(cateogoryId);
        if (category is null) throw new CategoryNotFoundException();

        // update category with new items 
        category.Name = dto.Name;
        category.UpdatedAt = TimeHelper.GetDateTime();
        category.UserId = dto.UserId;
        var dbResult = await _repository.UpdateAsync(cateogoryId, category);

        return dbResult > 0;
    }
}
