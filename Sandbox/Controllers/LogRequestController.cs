using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sandbox.Controllers
{
    [Route("log")]
    public class LogRequestController : Controller
    {
        private string LogFilePath = "log.txt";

        private class RequestLogEntry
        {
            public string Timestamp { get; private set; }
            public string UserAgent { get; private set; }
            public string Host { get; private set; }

            public RequestLogEntry(IHeaderDictionary headers)
            {
                Timestamp = $"{DateTime.Now.ToUniversalTime()}";
                UserAgent = headers["User-Agent"];
                Host = headers["Host"];
            }
        }

        private void WriteToLog(RequestLogEntry entry)
        {
            using (StreamWriter log = new StreamWriter(this.LogFilePath, true))
            {
                log.WriteLine(JsonConvert.SerializeObject(entry));
            }
        }

        [HttpGet]
        public string Get()
        {
            if (!System.IO.File.Exists(this.LogFilePath)) { return String.Empty; }

            using (StreamReader log = new StreamReader(this.LogFilePath))
            {
                return log.ReadToEnd();
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            WriteToLog(new RequestLogEntry(Request.Headers));
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            WriteToLog(new RequestLogEntry(Request.Headers));
            return Ok();
        }
    }
}
