using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class AppControllerBase : ControllerBase
{

}
