using FactoryStrategy.Interfaces;
using FactoryStrategy.Models;
using FactoryStrategy.Operations.Sync;
using FactoryStrategy.Strategy.CustomerSync;
using FactoryStrategy.Strategy.Heritage;
using Microsoft.Extensions.DependencyInjection;

public class OperationFactory
{
    private readonly IServiceProvider _provider;
    private readonly TenantType _tenant;

    public OperationFactory(IServiceProvider provider, TenantType tenant)
    {
        _provider = provider;
        _tenant = tenant;
    }


    public IOperation Create(OperationType type)
    {
        try
        {
            return (type, _tenant) switch
            {
                //if sync can be handled with verious strategies then we can use strategy pattern to resolve it
                (OperationType.CustomerSync, TenantType.Heritage) =>
                    new CustomerSync(_provider.GetRequiredService<CustomerSyncStrategy_1>()),
                (OperationType.CustomerSync, TenantType.Delta) =>
                    new CustomerSync(_provider.GetRequiredService<CustomerSyncStrategy_2>()),

                //if strategy is not able to resolve then we can directly create a new class for specific tenant and invoke it
                (OperationType.AssetSync, TenantType.Heritage) =>_provider.GetRequiredService<HeritageAssetSync>(),
                (OperationType.AssetSync, TenantType.Delta) => _provider.GetRequiredService<AssetSync>(),

                //continue with other operations
                _ => throw new NotImplementedException()
            };
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }


}
