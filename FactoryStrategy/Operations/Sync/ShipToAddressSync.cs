using FactoryStrategy.Interfaces;

public class ShipToAddressSync : IOperation
{
    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Console: Running Delta Customer Sync...");
        await Task.Delay(500);
    }
}
