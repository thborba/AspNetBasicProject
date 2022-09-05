namespace Infrastructure.Interfaces
{
    public interface ISubscribe
    {
        Task Subscribe<T>(Func<T, CancellationToken, Task> action, CancellationToken cancellationToken);
    }
}
