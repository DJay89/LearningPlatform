using System;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

public class PDFHandler
{

    PDDocument doc;
    PDFTextStripper stripper;
    String path;

    public PDFHandler()
    {
        this.doc = new PDDocument();
        this.stripper = new PDFTextStripper();
    }

    public PDDocument getDocument() { return doc; }

    public void setDocument(string path) { doc = PDDocument.load("path"); }

    public void setStartPage(int pageValue) { stripper.setStartPage(pageValue); }

    public void setEndPage(int pageValue) { stripper.setEndPage(pageValue); }

    public String getText() { return stripper.getText(doc); }

}
