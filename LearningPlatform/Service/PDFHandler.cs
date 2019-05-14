﻿using LearningPlatform.Models;
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
        pages = new List<PageModel>();

            try
            {
                reader = new PdfReader(path);
                extractPDF();
            }
            catch (Exception) { }
    }

    private void extractPDF()
    {
        for (int i = 1; i <= reader.NumberOfPages; i++) {
            PageModel model  = new PageModel();
            model.Content = PdfTextExtractor.GetTextFromPage(reader, i);
            pages.Add(model);
        }
    }

    public List<PageModel> getPages(int start, int end)
    {
        if (start == end)
            return pages;
        try { return pages.GetRange(start - 1, end - start); }
        catch (Exception) { return null; }
        
    }

    public List<PageModel> findPagesWithWord(string search)
    {
        if (pages.Count > 1)
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
        return null;
        
    }


}
