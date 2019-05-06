using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class FileUploadModel
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public int StartPage { get; set; }

        [Required]
        public int EndPage { get; set; }
           
        public List<PageModel> Pages { get; set; }
    }
}
