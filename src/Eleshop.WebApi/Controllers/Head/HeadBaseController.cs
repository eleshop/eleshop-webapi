using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eleshop.WebApi.Controllers.Head;

[ApiController]
[Authorize(Roles = "Head")]
public abstract class HeadBaseController : ControllerBase
{
}
