using LearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace LearningPlatform.Service
{
    public class TXTHandler
    {

        private List<PageModel> text;

        public List<PageModel> getText(string path)
        {
            text = new List<PageModel>();
            PageModel model = new PageModel();
            try { model.Content = File.ReadAllText(path); }
            catch (Exception) { model.Content = null; }
            text.Add(model);
            return text;
        }

    }
}
