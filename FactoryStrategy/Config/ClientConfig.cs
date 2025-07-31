using FactoryStrategy.Models;

namespace FactoryStrategy.Config
{
    public class ClientConfig
    {
        public string? Name { get; set; }
        public TenantType TenantType { get; set; }
        public List<OperationType>? EnabledOperations { get; set; }
    }
}
