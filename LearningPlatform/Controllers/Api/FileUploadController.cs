using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        // GET: api/FileUpload
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/FileUpload
        [HttpPost]
        public async Task<IActionResult> Post(FileUploadModel model)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempFileName();

                if (model.File.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(stream);
                    }
                }

                return Ok(new { filePath });
            }

            return Ok();
        }
    }
}
