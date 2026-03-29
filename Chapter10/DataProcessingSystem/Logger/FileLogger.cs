using DataProcessingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Logger
{
    public class FileLogger : ILogger
    {
        private readonly StringBuilder buffer = new StringBuilder();
        private readonly string path;

        public FileLogger(string path)
        {
            this.path = path;
        }

        public void Log(string message)
        {
            buffer.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }

        public void Save()
        {
            File.WriteAllText(path, buffer.ToString());
        }
    }
}
