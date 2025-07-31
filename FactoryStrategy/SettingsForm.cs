using FactoryStrategy.Config;
using FactoryStrategy.Models;

namespace FactoryStrategy
{
    public partial class SettingsForm : Form
    {
        private CheckBox chkAsset;
        private CheckBox chkProduct;
        private Button btnCancel;

        public ClientConfig UpdatedConfig { get; private set; }

        public SettingsForm(ClientConfig config)
        {
            InitializeComponent();
            UpdatedConfig = new ClientConfig
            {
                Name = config.Name,
                TenantType = config.TenantType,
                EnabledOperations = new List<OperationType>(config.EnabledOperations ?? new List<OperationType>())
            };
            LoadConfig();
        }
        private void LoadConfig()
        {
            chkAsset.Checked = UpdatedConfig.EnabledOperations?.Contains(OperationType.AssetSync) ?? false;
            chkProduct.Checked = UpdatedConfig.EnabledOperations?.Contains(OperationType.ProductSync) ?? false;
            chkCustomer.Checked = UpdatedConfig.EnabledOperations?.Contains(OperationType.CustomerSync) ?? false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdatedConfig.EnabledOperations = new List<OperationType>();

            if (chkAsset.Checked)
                UpdatedConfig.EnabledOperations.Add(OperationType.AssetSync);

            if (chkProduct.Checked)
                UpdatedConfig.EnabledOperations.Add(OperationType.ProductSync);

            if (chkCustomer.Checked)
                UpdatedConfig.EnabledOperations.Add(OperationType.CustomerSync);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
