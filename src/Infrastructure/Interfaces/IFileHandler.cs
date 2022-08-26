using Infrastructure.DTO;

namespace Infrastructure.Interfaces
{
    public interface IFileHandler
    {
        public IAsyncEnumerable<FileLineInfo> ReadFileLines(string path, CancellationToken cancellationToken);

        public void MoveFile(string currentPath, string destinationPath);
    }
}
