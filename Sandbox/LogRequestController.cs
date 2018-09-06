using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Sandbox
{
    public class LogRequestController : Controller
    {
        [HttpGet]
        [Route("log")]
        public IActionResult Log()
        {
            using (StreamWriter log = new StreamWriter("log.txt", true))
            {
                log.WriteLine($"{DateTime.Now}");
                log.WriteLine($"User-Agent: {Request.Headers["User-Agent"]}");
                log.WriteLine($"Host: {Request.Headers["Host"]}");
            }

            return Ok();
        }
    }
}
