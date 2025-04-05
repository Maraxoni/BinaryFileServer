using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFileServer
{
    public class FileService : IFileService
    {
        public string Echo(string text)
        {
            return "Echo: " + text;
        }

        public Stream DownloadImage(string name)
        {
            try
            {
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                string filePath = Path.Combine(projectDirectory, name);
                Console.WriteLine("Path to file: " + filePath);
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File found");
                    return new FileStream(filePath, FileMode.Open, FileAccess.Read);
                }
                else
                {
                    throw new FileNotFoundException("File not found", name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
