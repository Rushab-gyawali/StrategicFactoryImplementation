namespace FactoryStrategy.Strategy.CustomerSync
{
    public interface ICustomerSyncStrategy
    {
        Task ExecuteAsync(CancellationToken token = default);
        string CustomerFetchQuery(CancellationToken token = default);
    }
}
