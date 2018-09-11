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
        private string LogDirPath = "log/";

        private class RequestLogEntry
        {
            public string Timestamp { get; private set; }
            public string UserAgent { get; private set; }
            public string Host { get; private set; }
            public String Content { get; private set; }

            public RequestLogEntry(IHeaderDictionary headers, string content)
            {
                Timestamp = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                UserAgent = headers["User-Agent"];
                Host = headers["Host"];
                Content = content;
            }
        }

        private string GetLogDirPath(DateTime dateTime)
        {
            return Path.Combine(this.LogDirPath, dateTime.ToString("yyyy"));
        }

        private string GetLogFilePath(DateTime dateTime)
        {
            return Path.Combine(GetLogDirPath(dateTime), dateTime.ToString("MM-dd") + ".txt");
        }

        private void WriteToLog(RequestLogEntry entry)
        {
            Directory.CreateDirectory(GetLogDirPath(DateTime.Now));

            using (StreamWriter log = new StreamWriter(GetLogFilePath(DateTime.Now), true))
            {
                log.WriteLine(JsonConvert.SerializeObject(entry));
            }
        }

        [HttpGet]
        public string Get()
        {
            string logPath = GetLogFilePath(DateTime.Now);

            if (!System.IO.File.Exists(logPath)) { return String.Empty; }

            using (StreamReader log = new StreamReader(logPath))
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
