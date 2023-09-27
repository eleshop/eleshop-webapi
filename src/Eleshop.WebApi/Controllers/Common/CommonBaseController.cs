using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Common;

[ApiController]
[AllowAnonymous]
public abstract class CommonBaseController : ControllerBase
{
}
