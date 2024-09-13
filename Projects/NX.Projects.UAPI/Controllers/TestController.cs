using Microsoft.AspNetCore.Mvc;
using NX.Libs.CoreLib.Retval;

namespace NX.Projects.UAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
            
        }

        [HttpPost]
        public IActionResult Test()
        {
            Retval retval = new Retval();
            retval.Status = RetvalStatus.Success;
            return Ok();
        }
    }
}
