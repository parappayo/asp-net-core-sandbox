using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sandbox
{
    public class LogRequestController : Controller
    {
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

        private string GenerateLogEntryAsJson(IHeaderDictionary headers)
        {
            return JsonConvert.SerializeObject(new RequestLogEntry(headers));
        }

        [HttpGet]
        [Route("log")]
        public IActionResult Log()
        {
            string logEntry = GenerateLogEntryAsJson(Request.Headers);

            using (StreamWriter log = new StreamWriter("log.txt", true))
            {
                log.WriteLine(logEntry);
            }

            return Ok();
        }
    }
}
