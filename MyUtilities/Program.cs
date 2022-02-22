using System;
using System.Configuration;
using System.IO;

namespace MyUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = ConfigurationManager.AppSettings["PdfToWordFile"];
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Configured file not exists in the path");
                Console.Read();
            }
            //OCRConversion.ImagetoPdfConvertion(sourcePath);
            WordConverter.ConvertsPdfToWord(sourcePath);

        }
    }
}
