using LearningPlatform.Models;
using System.Collections.Generic;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;

public class PDFHandler
{

    private PdfReader reader;
    private List<PageModel> pages;

    public void setDocument(string path)
    {
        try {
            reader = new PdfReader(path);
            Extract();
        } catch (Exception e) { Console.WriteLine(e.Message); }
    }

    private void Extract()
    {
        pages = new List<PageModel>();

        for (int i = 1; i <= reader.NumberOfPages; i++) {
            PageModel model = new PageModel();
            model.Content = PdfTextExtractor.GetTextFromPage(reader, i);
            pages.Add(model);
        }
    }

    public List<PageModel> getPages(int start, int end)
    {
        if (start == end)
            return pages;
        return pages;
        return pages.GetRange(start - 1, end);
    }

    public List<PageModel> findPagesWithWord(string search)
    {
        List<PageModel> hits = new List<PageModel>();
        foreach (PageModel page in pages)
        {
            string[] words = page.Content.Split(' ');
            foreach (string word in words)
            {
                if (word.ToLower() == search.ToLower())
                {
                    hits.Add(page);
                    break;
                }
            }
        }
        return hits;
    }


}
