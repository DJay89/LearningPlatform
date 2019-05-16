using LearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace LearningPlatform.Service
{
    public class TXTHandler
    {

        private List<PageModel> text;

        public List<PageModel> getText(IFormFile file)
        {
            text = new List<PageModel>();
            PageModel model = new PageModel();

            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                model.Content = reader.ReadToEnd();
            }
            text.Add(model);
            return text;
        }

    }
}
