using Eleshop.Application.Utilities;
using Eleshop.Services.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Common.Categories;

[Route("api/common/categories")]
[ApiController]
public class CommonCategoriesController : CommonBaseController
{
    private readonly ICategoryService _service;
    private readonly int maxPageSize = 30;

    public CommonCategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
        => Ok(await _service.GetByIdAsync(categoryId));
}
