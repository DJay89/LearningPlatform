using LearningPlatform.Models;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System.Collections.Generic;

public class PDFHandler
{

    private PDDocument doc;
    private PDFTextStripper stripper;
    private List<PageModel> pages;

    public PDFHandler()
    {
        this.doc = new PDDocument();
        this.stripper = new PDFTextStripper();
    }

    public PDDocument getDocument() { return doc; }

    public void setDocument(string path)
    {
        doc = PDDocument.load("path");
        Extract();
    }

    private void Extract()
    {
        pages = new List<PageModel>();

        for (int i = 0; i < doc.getNumberOfPages(); i++) {
            stripper.setStartPage(i);
            stripper.setEndPage(i + 1);

            PageModel model  = new PageModel();
            model.Content = stripper.getText(doc);
            pages.Add(model);
        }
    }

    public List<PageModel> getPages()
    {
        return pages;
    }

    public List<PageModel> getPagesBetween(int start, int forward)
    {
        return pages.GetRange(start-1, forward);
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
