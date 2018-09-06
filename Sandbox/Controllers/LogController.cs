using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sandbox.Controllers
{
    [Route("log")]
    public class LogController : Controller
    {
        private string LogFilePath = "log.txt";

        private class RequestLogEntry
        {
            public string Timestamp { get; private set; }
            public string UserAgent { get; private set; }
            public string Host { get; private set; }
            public String Content { get; private set; }

            public RequestLogEntry(IHeaderDictionary headers, string content)
            {
                Timestamp = $"{DateTime.Now.ToUniversalTime()}";
                UserAgent = headers["User-Agent"];
                Host = headers["Host"];
                Content = content;
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
        public IActionResult Put(string content)
        {
            WriteToLog(new RequestLogEntry(Request.Headers, content));
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            using (StreamReader body = new StreamReader(Request.Body))
            {
                WriteToLog(new RequestLogEntry(Request.Headers, body.ReadToEnd()));
            }

            return Ok();
        }
    }
}
