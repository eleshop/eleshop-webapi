using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.User;

[ApiController]
[Authorize(Roles = "User")]
public abstract class UserBaseController : ControllerBase
{
}
