using Domain.Configuration;
using Domain.Interfaces;
using Infrastructure.DTO;
using Infrastructure.Interfaces;

namespace Domain.Services
{
    public class ReadFile : IReadFile
    {
        private readonly FileReaderOptions _fileReaderOptions;
        private readonly IFileHandler _fileHandler;

        public ReadFile(IFileHandler fileHandler, FileReaderOptions fileReaderOptions)
        {
            _fileHandler = fileHandler;
            _fileReaderOptions = fileReaderOptions;
        }

        public List<FileDetails> ReadProcessedFiles() => _fileHandler.ReadFiles(_fileReaderOptions.ProcessedFilesPath);
    }
}
