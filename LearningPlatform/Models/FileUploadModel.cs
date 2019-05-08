using LearningPlatform.Models.Validators;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class FileUploadModel
    {
        [Required(ErrorMessage = "You must provide a file")]
        public IFormFile File { get; set; }

        [Required]
        [Range(1, int.MaxValue - 1, ErrorMessage = "First page must be equal or greater than 1")]
        public int StartPage { get; set; }

        [Required]
        [PageValidate]
        public int EndPage { get; set; }
           
        public List<PageModel> Pages { get; set; }

        public FileUploadModel()
        {
            this.StartPage = 1;
            this.EndPage = 2;
            this.Pages = new List<PageModel>();
        }
    }
}
