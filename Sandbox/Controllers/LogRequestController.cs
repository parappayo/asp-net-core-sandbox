﻿using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sandbox.Controllers
{
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

        private string GenerateLogEntryAsJson(IHeaderDictionary headers)
        {
            return JsonConvert.SerializeObject(new RequestLogEntry(headers));
        }

        [HttpGet]
        [Route("log")]
        public string GetLog()
        {
            if (!System.IO.File.Exists(this.LogFilePath)) { return String.Empty; }

            using (StreamReader log = new StreamReader(this.LogFilePath))
            {
                return log.ReadToEnd();
            }
        }

        [HttpPut]
        [Route("log")]
        public IActionResult PutLog()
        {
            string logEntry = GenerateLogEntryAsJson(Request.Headers);

            using (StreamWriter log = new StreamWriter(this.LogFilePath, true))
            {
                log.WriteLine(logEntry);
            }

            return Ok();
        }
    }
}