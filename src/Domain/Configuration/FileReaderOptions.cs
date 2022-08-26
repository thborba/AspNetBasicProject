namespace Domain.Configuration
{
    public class FileReaderOptions
    {

        public FileReaderOptions() { }

        public FileReaderOptions(string processedFilesPath)
        {
            ProcessedFilesPath = processedFilesPath;
        }

        public string ProcessedFilesPath { get; set; } 
    }
}
