using FactoryStrategy.Config;
using FactoryStrategy.Operations.Sync;
using FactoryStrategy.Strategy.CustomerSync;
using FactoryStrategy.Strategy.Heritage;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceProvider ConfigureServices(ClientConfig client)
    {
        var services = new ServiceCollection();

        // Register per operation per tenant
        services.AddTransient<ProductSync>();
        services.AddTransient<ShipToAddressSync>();
        services.AddTransient<AssetSync>();

        //if specific class is required for a tenant then we can register it here
        //and then process it without strategies.
        services.AddTransient<HeritageAssetSync>();

        services.AddScoped<CustomerSyncStrategy_1>();
        services.AddScoped<CustomerSyncStrategy_2>();
        //add other strategies as needed


        // Factory & service
        services.AddSingleton(client);
        services.AddSingleton<OperationFactory>(sp => new OperationFactory(sp, client.TenantType));
        services.AddSingleton<SyncBackgroundService>();

        return services.BuildServiceProvider();
    }
}
