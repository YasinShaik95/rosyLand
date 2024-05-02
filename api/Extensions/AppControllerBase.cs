using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api;
[Authorize]
[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class AppControllerBase : ControllerBase
{

}
