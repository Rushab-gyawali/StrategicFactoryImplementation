namespace FactoryStrategy.Strategy.CustomerSync
{
    /// <summary>
    /// Delta implementation of the customer sync strategy.
    /// </summary>
    public class CustomerSyncStrategy_2 : ICustomerSyncStrategy
    {
        public string CustomerFetchQuery(CancellationToken token = default)
        {
            string sql = "select * from Customers where SyncStatus = 'Delta'";
            return sql;
        }

        public async Task ExecuteAsync(CancellationToken token = default)
        {
            Console.WriteLine("Running Delta Customer Sync...");
            await Task.Delay(500, token);
        }
    }
}
