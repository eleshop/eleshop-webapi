using Eleshop.Persistance.Dtos.Accessories;
using Eleshop.Services.Interfaces.Accessories;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Admin.Accessories;

[Route("api/admin/accessories")]
[ApiController]
public class AdminAccessoriesController : AdminBaseController
{
    private readonly IAccessoryService _service;

    public AdminAccessoriesController(IAccessoryService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AccessoryCreateDto dto)
    {
        //var validator = new CategoryCreateValidator();
        //var result = validator.Validate(dto);
        //if (result.IsValid)
        return Ok(await _service.CreateAsync(dto));
        //else return BadRequest(result.Errors);
    }

    [HttpPut("{accessoryId}")]
    public async Task<IActionResult> UpdateAsync(long accessoryId, [FromForm] AccessoryUpdateDto dto)
    {
        //var updateValidator = new AccessoryUpdateValidator();
        //var validationResult = updateValidator.Validate(dto);
        //if (validationResult.IsValid)
        return Ok(await _service.UpdateAsync(accessoryId, dto));
        //else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{accessoryId}")]
    public async Task<IActionResult> DeleteAsync(long accessoryId)
        => Ok(await _service.DeleteAsync(accessoryId));
}
