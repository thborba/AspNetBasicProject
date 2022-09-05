using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EventHandlers.Events
{
    public class FileLineEvent
    {
        public string FileName { get; set; }
        public string Content { get; set; }

        public FileLineEvent(string fileName, string content)
        {
            FileName = fileName;
            Content = content;
        }
    }
}
