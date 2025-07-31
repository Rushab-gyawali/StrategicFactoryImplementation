using FactoryStrategy.Config;

namespace FactoryStrategy
{
    public partial class Form1 : Form
    {
        private readonly SyncBackgroundService _syncService;
        private ClientConfig clientConfig;
        IServiceProvider _provider;
        public Form1(SyncBackgroundService syncService, ClientConfig config, IServiceProvider provider)
        {
            InitializeComponent();
            _syncService = syncService;
            clientConfig = config;
            _provider = provider;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm(clientConfig))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    clientConfig = settingsForm.UpdatedConfig;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var operationFactory = new OperationFactory(_provider, clientConfig.TenantType);
            var syncService = new SyncBackgroundService(operationFactory, clientConfig);

            try
            {
                syncService?.Start();
                MessageBox.Show("Sync completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sync failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
