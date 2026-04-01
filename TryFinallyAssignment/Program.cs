using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryFinallyAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService();
            string filePath = "sample.txt";

            string content = fileService.ReadFileContent(filePath);
            Console.WriteLine(content);
        }
    }

    public class FileService
    {
        public string ReadFileContent(string filePath)
        {
            StreamReader streamReader = null;
            string fileContent = string.Empty;

            try
            {
                streamReader = new StreamReader(filePath);
                fileContent = streamReader.ReadToEnd();
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }

                Console.WriteLine("File resource cleaned up successfully.");
            }

            return fileContent;
        }
    }
}
