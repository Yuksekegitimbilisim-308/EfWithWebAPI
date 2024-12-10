using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EfWithWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet("write-log")]
        public IActionResult WriteLog([FromQuery] string log)
        {
            Debug.WriteLine($"Alınan Log Kayıdı : {log}");
            return Ok();
        }
    }
}
