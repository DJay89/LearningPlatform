using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System.Collections.Generic;

public class PDFHandler
{

    private PDDocument doc;
    private PDFTextStripper stripper;
    private List<string> pages;
    private string path;

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
        pages = new List<string>();

        for (int i = 0; i < doc.getNumberOfPages(); i++) {
            stripper.setStartPage(i);
            stripper.setEndPage(i + 1);
            pages.Add(stripper.getText(doc));
        }
    }

    public List<string> getPages()
    {
        return pages;
    }

    public List<string> getPagesBetween(int start, int forward)
    {
        return pages.GetRange(start-1, forward);
    }

    public List<string> findPagesWithWord(string search)
    {
        List<string> hits = new List<string>();
        foreach (string page in pages)
        {
            string[] words = page.Split(' ');
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
