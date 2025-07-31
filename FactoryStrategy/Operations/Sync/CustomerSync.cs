using FactoryStrategy.Interfaces;
using FactoryStrategy.Strategy.CustomerSync;

public class CustomerSync : IOperation
{
    private readonly ICustomerSyncStrategy _strategy;

    public CustomerSync(ICustomerSyncStrategy strategy)
    {
        _strategy = strategy;
    }
    public async Task ExecuteAsync(CancellationToken token = default)
    {
        var query = _strategy.CustomerFetchQuery(token);
        //execute query
        await _strategy.ExecuteAsync(token);
    }
}

