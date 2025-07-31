namespace FactoryStrategy.Interfaces
{
    public interface IOperation
    {
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
