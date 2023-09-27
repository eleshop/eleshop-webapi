using Eleshop.Application.Utilities;
using Eleshop.Services.Interfaces.Laptops;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Common.Laptops;

[Route("api/common/laptops")]
[ApiController]
public class CommonLaptopsController : ControllerBase
{
    private readonly ILaptopService _service;
    private readonly int maxPageSize = 30;

    public CommonLaptopsController(ILaptopService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
    => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{laptopId}")]
    public async Task<IActionResult> GetByIdAsync(long laptopId)
        => Ok(await _service.GetByIdAsync(laptopId));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());
}
