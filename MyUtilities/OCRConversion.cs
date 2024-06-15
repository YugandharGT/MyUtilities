using System;
using System.Collections.Generic;
using System.Text;

namespace MyUtilities
{
    public static class OCRConversion
    {
        //public static void ImagetoPdfConvertion(string imageFilePath)
        //{
        //    using (var api = OcrApi.Create())
        //    {
        //       api.Init(Languages.English);
        //       using (var renderer = OcrPdfRenderer.Create("multipagepdffile", @"D:\"))
        //       {
        //           renderer.BeginDocument("Title");
        //           api.ProcessPages(imageFilePath, null, 0, renderer); //@"C:\Tapas\multidocs.tif"
        //           renderer.EndDocument();
        //       }
        //    }
        //}

        /// <summary>
        /// Converts an image to a PDF document and saves it to a specified output path.
        /// </summary>
        /// <param name="imageFilePath">The path to the image file.</param>
        /// <param name="pdfOutputPath">The path to save the generated PDF document.</param>
        //public static void ImagetoPdfConvertion(string imageFilePath, string pdfOutputPath)
        //{
        //    // Create an instance of the OcrApi class
        //    using (var api = OcrApi.Create())
        //    {
        //        // Initialize the OCR API with the specified language
        //        api.Init(Languages.English);

        //        // Create a PDF document from the image file
        //        using (var pdfDocument = api.CreatePDFFromImage(imageFilePath))
        //        {
        //            // Save the PDF document to the specified output path
        //            pdfDocument.Save(pdfOutputPath);
        //        }
        //    }
        //}   
    }
}
