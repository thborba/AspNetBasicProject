using Domain.Configuration;
using Domain.EventHandlers.Events;
using Domain.Interfaces;
using Infrastructure.DTO;
using Infrastructure.Interfaces;

namespace Domain.Services
{
    public class ProcessFile : IProcessFile
    {
        private readonly IPublish _publish;
        private readonly IFileHandler _fileHandler;
        private readonly FileReaderOptions _fileReaderOptions;

        public ProcessFile(IFileHandler fileHandler, FileReaderOptions fileReaderOptions, IPublish publish)
        {
            _publish = publish;
            _fileHandler = fileHandler;
            _fileReaderOptions = fileReaderOptions;
        }

        public async Task Execute(string path, CancellationToken cancellationToken)
        {
            var fileLines = _fileHandler.ReadFileLines(path, cancellationToken);
            await foreach (FileLineInfo line in fileLines)
                await _publish.Publish(new FileLineEvent(line.FileName, line.Content), cancellationToken);
            _fileHandler.MoveFile(path, _fileReaderOptions.ProcessedFilesPath);
        }
    }
}
