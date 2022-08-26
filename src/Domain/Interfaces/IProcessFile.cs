namespace Domain.Interfaces
{
    public interface IProcessFile
    {
        public Task Execute(string path, CancellationToken cancellationToken);
    }
}
