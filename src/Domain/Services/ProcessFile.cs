using Domain.Configuration;
using Domain.Interfaces;
using Infrastructure.DTO;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Domain.Services
{
    public class ProcessFile : IProcessFile
    {
        public event EventHandler<FileLineInfo> FileLineRead;
        private readonly FileReaderOptions _fileReaderOptions;
        private readonly IFileHandler _fileHandler;

        public ProcessFile(IFileHandler fileHandler, FileReaderOptions fileReaderOptions)
        {
            FileLineRead += OnFileLineRead;
            _fileHandler = fileHandler;
            _fileReaderOptions = fileReaderOptions;
        }

        private static void OnFileLineRead(object source, FileLineInfo e) => System.Diagnostics.Debug.WriteLine(e.FileName + " | " + e.Content);

        public async Task Execute(string path, CancellationToken cancellationToken)
        {
            var fileLines = _fileHandler.ReadFileLines(path, cancellationToken);
            await foreach (FileLineInfo line in fileLines)
                FileLineRead.Invoke(this, new FileLineInfo(line.FileName, line.Content));
            _fileHandler.MoveFile(path, _fileReaderOptions.ProcessedFilesPath);
        }
    }
}
