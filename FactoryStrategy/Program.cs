using FactoryStrategy;
using FactoryStrategy.Config;
using FactoryStrategy.Models;
using Microsoft.Extensions.DependencyInjection;

static class Program
{
    [STAThread]
    static void Main()
    {
        var client = new ClientConfig
        {
            Name = "Heritage Client",
            TenantType = TenantType.Heritage,
            EnabledOperations = new List<OperationType>
            {
                OperationType.CustomerSync,
                OperationType.ProductSync,
                //OperationType.AssetSync
            }
        };

        var provider = DependencyInjection.ConfigureServices(client);

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(provider.GetRequiredService<SyncBackgroundService>(),client,provider));
    }
}
