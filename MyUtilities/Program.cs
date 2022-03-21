using System;
using System.Configuration;
using System.IO;
using MyUtilities;

namespace MyUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            var plainPwd = "Sekar8@yuga";
            var hashedPwd = SecurityOperations.EncryptString(plainPwd);
            Console.WriteLine($"Encrypted pwd is: {hashedPwd}");
            var decodedPwd = SecurityOperations.DecryptString(hashedPwd);
            Console.WriteLine($"Encrypted pwd is: {decodedPwd}");

            // string sourcePath = ConfigurationManager.AppSettings["PdfToWordFile"];
            // if (!File.Exists(sourcePath))
            // {
            //     Console.WriteLine("Configured file not exists in the path");
            //     Console.Read();
            // }
            //WordConverter.ConvertsPdfToWord(sourcePath);

            //OCRConversion.ImagetoPdfConvertion(sourcePath);

        }
    }
}
