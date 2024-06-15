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

            //new WrapperClass("", "").InitiateOcrConversion();
           
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
        private readonly string _pdfFilePath;   

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

        public WrapperClass(string imgFilePath, string pdfFilePath)
        {
            _filePath = imgFilePath;
            _pdfFilePath = pdfFilePath;
        }

        /// <summary>
        /// Initiates the conversion of a PDF file to a Word document.
        /// </summary>
        /// <remarks>
        /// This method retrieves the file path of the PDF file from the application configuration.
        /// It then checks if the file exists at the specified path.
        /// If the file path is not provided or the file does not exist, an error message is displayed and the method returns.
        /// If the file exists, the <see cref="WordConverter.ConvertsPdfToWord(string)"/> method is called to perform the conversion.
        /// If an error occurs during the conversion, an error message is displayed.
        /// </remarks>
        public void InitiateConversion()
        {
            // Get the file path of the PDF file from the application configuration
            string sourcePath = ConfigurationManager.AppSettings["PdfToWordFile"];

            // Check if the file path is null or empty
            if (string.IsNullOrEmpty(sourcePath))
            {
                // Display an error message and return
                Console.WriteLine("Configured file path is either null or empty");
                Console.Read();
                return;
            }

            // Check if the file exists at the specified path
            if (!File.Exists(sourcePath))
            {
                // Display an error message and return
                Console.WriteLine("Configured file not exists in the path");
                Console.Read();
                return;
            }

            try
            {
                // Call the method to perform the conversion
                WordConverter.ConvertsPdfToWord(sourcePath);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs during the conversion
                Console.WriteLine($"An error occurred while initiating conversion: {ex.Message}");
                Console.Read();
            }
        }

        public void InitiateOcrConversion()
        {
            //OCRConversion.ImagetoPdfConvertion(_filePath, _pdfFilePath);
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
