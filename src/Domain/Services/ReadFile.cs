using Domain.DTO;
using Domain.Interfaces;

namespace Domain.Services
{
    public class ReadFile : IReadFile
    {
        public IAsyncEnumerable<FileDetails> ReadProcessedFiles(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
