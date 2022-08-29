using Infrastructure.DTO;

namespace Infrastructure.Interfaces
{
    public interface IFileHandler
    {

        public List<FileDetails> ReadFiles(string path);

        public IAsyncEnumerable<FileLineInfo> ReadFileLines(string path, CancellationToken cancellationToken);

        public void MoveFile(string currentPath, string destinationPath);
    }
}
