using Infrastructure.DTO;
using Infrastructure.Interfaces;
using System.IO;
using System.Runtime.CompilerServices;

namespace Infrastructure.Services
{
    public class FileHandler : IFileHandler
    {
        public async IAsyncEnumerable<FileLineInfo> ReadFileLines(string path, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            using var file = new StreamReader(path);
            var fileName = Path.GetFileName(path);
            while (!cancellationToken.IsCancellationRequested)
            {
                string? line = await file.ReadLineAsync();
                if (line == null)
                    break;
                yield return new FileLineInfo(fileName, line);
            }
        }

        public void MoveFile(string currentPath, string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);
            var fileName = Path.GetFileName(currentPath);
            File.Move(currentPath, Path.Combine(destinationPath, fileName));
        }
    }
}