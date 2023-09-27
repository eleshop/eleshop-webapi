using Eleshop.Persistance.Dtos.Accessories;
using Eleshop.Persistance.Dtos.Laptops;
using Eleshop.Services.Interfaces.Accessories;
using Eleshop.Services.Interfaces.Laptops;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Admin.Laptops;

[Route("api/admin/laptops")]
[ApiController]
public class AdminLaptopsController : AdminBaseController
{
    private readonly ILaptopService _service;

    public AdminLaptopsController(ILaptopService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] LaptopCreateDto dto)
    {
        //var validator = new CategoryCreateValidator();
        //var result = validator.Validate(dto);
        //if (result.IsValid)
        return Ok(await _service.CreateAsync(dto));
        //else return BadRequest(result.Errors);
    }

    [HttpPut("{laptopId}")]
    public async Task<IActionResult> UpdateAsync(long laptopId, [FromForm] LaptopUpdateDto dto)
    {
        //var updateValidator = new AccessoryUpdateValidator();
        //var validationResult = updateValidator.Validate(dto);
        //if (validationResult.IsValid)
        return Ok(await _service.UpdateAsync(laptopId, dto));
        //else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{laptopId}")]
    public async Task<IActionResult> DeleteAsync(long laptopId)
        => Ok(await _service.DeleteAsync(laptopId));
}
