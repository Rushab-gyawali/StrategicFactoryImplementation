using FactoryStrategy.Interfaces;

public class AssetSync : IOperation
{
    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Console: Running Asset Sync for all tenants...");
        await Task.Delay(500);
    }
}
