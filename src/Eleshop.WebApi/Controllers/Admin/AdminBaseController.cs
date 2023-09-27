using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Eleshop.WebApi.Controllers.Admin;

[ApiController]
//[Authorize(Roles = "Admin, Administrator, Head")]
[AllowAnonymous]
public class AdminBaseController : ControllerBase
{
}
