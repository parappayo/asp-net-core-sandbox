using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sandbox.Controllers
{
    [Route("upload")]
    public class UploadController : Controller
    {
        private string SaveFilePath = "uploads";

        public UploadController()
        {
            if (!Directory.Exists(SaveFilePath))
            {
                Directory.CreateDirectory(SaveFilePath);
            }
        }

        [HttpPost]
        public IActionResult Post(List<IFormFile> uploadFiles)
        {
            foreach (var file in uploadFiles)
            {
                SaveFormFile(file);
            }

            return Ok();
        }

        private void SaveFormFile(IFormFile formFile)
        {
            if (formFile.Length <= 0) { return; }

            string filePath = Path.Combine(SaveFilePath, EscapeFileName(formFile.FileName));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
        }

        private string EscapeFileName(string fileName)
        {
            StringBuilder result = new StringBuilder(fileName);

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                result.Replace(c, '-');
            }

            return result.ToString();
        }
    }
}
