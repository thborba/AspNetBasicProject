using Domain.DTO;

namespace Domain.Interfaces
{
    public interface IReadFile
    {
        public IAsyncEnumerable<FileDetails> ReadProcessedFiles(CancellationToken cancellationToken);
    }
}
