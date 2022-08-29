using Infrastructure.DTO;

namespace Domain.Interfaces
{
    public interface IReadFile
    { 
        public List<FileDetails> ReadProcessedFiles();
    }
}
