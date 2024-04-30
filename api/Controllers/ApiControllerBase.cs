using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ApiControllerBase : ControllerBase
{

}
