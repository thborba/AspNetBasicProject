namespace Domain.Interfaces
{
    public interface IProcessFile
    {
        Task Execute(string path, CancellationToken cancellationToken);
    }
}
