using Infrastructure.DTO;

namespace Domain.Interfaces
{
    public interface IReadFile
    { 
        List<FileDetails> ReadProcessedFiles();
    }
}
