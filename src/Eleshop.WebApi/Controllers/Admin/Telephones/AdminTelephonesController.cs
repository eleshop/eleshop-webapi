using Eleshop.Persistance.Dtos.Telephones;
using Eleshop.Services.Interfaces.Telephones;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Admin.Telephones;

[Route("api/admin/telephones")]
[ApiController]
public class AdminTelephonesController : AdminBaseController
{
    private readonly ITelephoneService _service;

    public AdminTelephonesController(ITelephoneService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] TelephoneCreateDto dto)
    {
        //var validator = new CategoryCreateValidator();
        //var result = validator.Validate(dto);
        //if (result.IsValid)
        return Ok(await _service.CreateAsync(dto));
        //else return BadRequest(result.Errors);
    }

    [HttpPut("{telephoneId}")]
    public async Task<IActionResult> UpdateAsync(long telephoneId, [FromForm] TelephoneUpdateDto dto)
    {
        //var updateValidator = new AccessoryUpdateValidator();
        //var validationResult = updateValidator.Validate(dto);
        //if (validationResult.IsValid)
        return Ok(await _service.UpdateAsync(telephoneId, dto));
        //else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{telephoneId}")]
    public async Task<IActionResult> DeleteAsync(long telephoneId)
        => Ok(await _service.DeleteAsync(telephoneId));
}
