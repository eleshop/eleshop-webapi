using Eleshop.Application.Utilities;
using Eleshop.Services.Interfaces.Accessories;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Common.Accessories;

[Route("api/common/accessories")]
[ApiController]
public class CommonAccessoriesController : CommonBaseController
{
    private readonly IAccessoryService _service;
    private readonly int maxPageSize = 30;

    public CommonAccessoriesController(IAccessoryService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
    => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{accessoryId}")]
    public async Task<IActionResult> GetByIdAsync(long accessoryId)
        => Ok(await _service.GetByIdAsync(accessoryId));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());
}
