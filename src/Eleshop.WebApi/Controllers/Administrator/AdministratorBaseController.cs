using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Administrator;

[ApiController]
[Authorize(Roles = "Administrator, Head")]
public abstract class AdministratorBaseController : ControllerBase
{
}
