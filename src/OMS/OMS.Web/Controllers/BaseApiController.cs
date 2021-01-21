using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OMS.Web
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {

    }
}
