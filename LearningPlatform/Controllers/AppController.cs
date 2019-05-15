using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers
{
    public class AppController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new FileUploadModel());
        }

        public IActionResult page2()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Index(FileUploadModel model)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempFileName();

                if (model.File.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.File.CopyToAsync(stream);
                    }
                }

                PDFHandler pdfHandler = new PDFHandler();
                pdfHandler.SetDocument(model.File);
                List<PageModel> pages = pdfHandler.getPages(model.StartPage, model.EndPage);
                model.Pages = pages;
            }

            return View(model);
        }
    }
}