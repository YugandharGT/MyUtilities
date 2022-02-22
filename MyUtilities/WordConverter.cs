using System;
using System.Diagnostics;
using System.IO;

namespace MyUtilities
{
    /// <summary>
    /// 
    /// </summary>
    public class WordConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFilePath">Pass Full file path without spaces in the file name</param>
        public static void ConvertsPdfToWord(string sourcePdfFilePath)
        {
            Console.WriteLine("Conversion from pdf to word started...");
            string pdfFile = sourcePdfFilePath; // @"c:\book.pdf";
            MemoryStream docxStream = new MemoryStream();
            // Convert PDF to word in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // Assume that we already have a PDF document as stream.
            using (FileStream pdfStream = new FileStream(pdfFile, FileMode.Open, FileAccess.Read))
            {
                f.OpenPdf(pdfStream);

                if (f.PageCount > 0)
                {
                    int res = f.ToWord(docxStream);

                    // Save docxStream to a file for demonstration purposes.
                    if (res == 0)
                    {
                        string docxFile = Path.ChangeExtension(pdfFile, WordConstants.WORD_EXT);
                        File.WriteAllBytes(docxFile, docxStream.ToArray());

                        //var proc = Process.Start(@"cmd.exe ", @"/c " + docxFile);
                        var proc = Process.Start(WordConstants.DOS_EXE, string.Join("", WordConstants.TERMINATE_AFTER_PROCESS_COMPLETION, docxFile));

                        //var p = new Process();
                        //p.StartInfo = new ProcessStartInfo(docxFile)
                        //{
                        //    UseShellExecute = true
                        //};
                        //p.Start();
                    }
                }
            }
            Console.WriteLine("Conversion to word has been completed");
            Console.Read();
        }

        public static void ConvertImageToPdf(string sourceImageFilePath)
        {
            //string filePath = Server.MapPath("~/Uploads/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            //FileUpload1.SaveAs(filePath);

            //Initialize the PDF document object.
            //using (Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
            //{
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //    pdfDoc.Open();

            //    //Add the Image file to the PDF document object.
            //    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(filePath);
            //    pdfDoc.Add(img);
            //    pdfDoc.Close();

            //    //Download the PDF file.
            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("content-disposition", "attachment;filename=ImageExport.pdf");
            //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //    Response.Write(pdfDoc);
            //    Response.End();

            //}
        }

        public static void ConvertMultipleImageToSinglePdf(string sourceImageFilePath)
        {

        }
    }


    public static class WordConstants
    {
        public const string WORD_EXT = ".docx";
        public const string DOS_EXE = "cmd.exe ";
        public const string TERMINATE_AFTER_PROCESS_COMPLETION = "/c ";
    }
}
