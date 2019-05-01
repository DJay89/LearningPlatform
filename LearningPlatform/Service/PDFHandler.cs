using System;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

public class PDFHandler
{

    PDDocument doc;
    PDFTextStripper stripper;
    string path;
    int start, end;

    public PDFHandler()
    {
        this.doc = new PDDocument();
        this.stripper = new PDFTextStripper();
    }

    public PDDocument getDocument() { return doc; }

    public void setDocument(string path)
    {
        doc = PDDocument.load("path");
        stripper.setStartPage(0);
        stripper.setEndPage(doc.getNumberOfPages()-1);
    }

    public string[] getText()
    {
        string[] pages = new string[end - start];
        int page = 0;

        for (int i = start; i <= end; i++) {
            stripper.setStartPage(i);
            stripper.setEndPage(i + 1);
            pages[page++] = stripper.getText(doc);
        }
        return pages;
    }

    public void setStartPage(int pageValue) { start = pageValue; }

    public void setEndPage(int pageValue) { end = pageValue; }

}
