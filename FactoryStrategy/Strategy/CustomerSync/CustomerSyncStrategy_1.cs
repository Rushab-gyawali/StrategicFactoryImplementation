
using FactoryStrategy.Strategy.CustomerSync;

namespace FactoryStrategy.Strategy.Heritage
{
    /// <summary>
    /// Heritage implementation of the customer sync strategy.
    /// </summary>
    public class CustomerSyncStrategy_1 : ICustomerSyncStrategy
    {
        public string CustomerFetchQuery(CancellationToken token = default)
        {
            string sql = "select * from Customers";
            return sql;
        }

        public async Task ExecuteAsync(CancellationToken token = default)
        {
            Console.WriteLine("Running Heritage Customer Sync...");
            await Task.Delay(500, token);

        }
    } 
}
