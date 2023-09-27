using Eleshop.Application.Utilities;
using Eleshop.Services.Interfaces.Telephones;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Common.Telephones;

[Route("api/common/telephones")]
[ApiController]
public class CommonTelephonesController : CommonBaseController
{
    private readonly ITelephoneService _service;
    private readonly int maxPageSize = 30;

    public CommonTelephonesController(ITelephoneService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
    => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{telephoneId}")]
    public async Task<IActionResult> GetByIdAsync(long telephoneId)
        => Ok(await _service.GetByIdAsync(telephoneId));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());
}
