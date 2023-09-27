using Eleshop.Persistance.Dtos.Users;
using Eleshop.Persistance.Validations.Users;
using Eleshop.Services.Interfaces.Auth;
using Eleshop.Services.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.User.Users;

[Route("api/user/profile")]
[ApiController]
public class UserController : UserBaseController
{
    private readonly IIdentityService _identity;
    private readonly IUserService _service;

    public UserController(IUserService service,
         IIdentityService identity)
    {
        this._identity = identity;
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync()
        => Ok(await _service.GetByIdAsync(_identity.Id));

    [HttpPut("userId")]
    public async Task<IActionResult> UpdateAsync([FromForm] UserUpdateDto dto)
    {
        var updateValidator = new UserUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(_identity.Id, _identity.PhoneNumber, dto));
        else return BadRequest(validationResult.Errors);
    }
}
