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

            new WrapperClass(new SecurityOperations());
           
        }
    }

    public interface IWrapper
    {
        public void InitiateSecurity();

        public void InitiateConversion();

        public void InitiateOcrConversion();
    }
    public class WrapperClass : IWrapper
    {
        private readonly SecurityOperations _security;
        private readonly WordConverter _converter;
        private readonly string _filePath;

        public WrapperClass()
        {

        }
        public WrapperClass(SecurityOperations security)
        {
            _security = security;
        }
        public WrapperClass(WordConverter converter)
        {
            _converter = converter;
        }

        public WrapperClass(string filePath)
        {
            _filePath = filePath;
        }

        public void InitiateConversion()
        {
            string sourcePath = ConfigurationManager.AppSettings["PdfToWordFile"];
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Configured file not exists in the path");
                Console.Read();
            }
            WordConverter.ConvertsPdfToWord(sourcePath);
        }

        public void InitiateOcrConversion()
        {
            OCRConversion.ImagetoPdfConvertion(_filePath);
        }

        public void InitiateSecurity()
        {
            var plainPwd = "Sekar8@yuga";
            var hashedPwd = _security.EncryptString(plainPwd);
            Console.WriteLine($"Encrypted pwd is: {hashedPwd}");
            var decodedPwd = _security.DecryptString(hashedPwd);
            Console.WriteLine($"Encrypted pwd is: {decodedPwd}");

        }
    }
}
