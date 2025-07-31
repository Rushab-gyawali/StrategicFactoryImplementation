using FactoryStrategy.Models;

namespace FactoryStrategy
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chkAsset = new CheckBox();
            chkProduct = new CheckBox();
            btnCancel = new Button();
            chkCustomer = new CheckBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // chkAsset
            // 
            chkAsset.Location = new Point(31, 85);
            chkAsset.Name = "chkAsset";
            chkAsset.Size = new Size(104, 27);
            chkAsset.TabIndex = 0;
            chkAsset.Text = "Sync Asset";
            // 
            // chkProduct
            // 
            chkProduct.Location = new Point(30, 118);
            chkProduct.Name = "chkProduct";
            chkProduct.Size = new Size(104, 27);
            chkProduct.TabIndex = 1;
            chkProduct.Text = "Sync Product";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(229, 266);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancle";
            // 
            // chkCustomer
            // 
            chkCustomer.AutoSize = true;
            chkCustomer.Location = new Point(31, 60);
            chkCustomer.Name = "chkCustomer";
            chkCustomer.Size = new Size(103, 19);
            chkCustomer.TabIndex = 5;
            chkCustomer.Text = "SyncCustomer";
            chkCustomer.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(310, 266);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(395, 301);
            Controls.Add(chkCustomer);
            Controls.Add(chkAsset);
            Controls.Add(chkProduct);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            var ops = new List<OperationType>();
            if (chkAsset.Checked) ops.Add(OperationType.AssetSync);
            if (chkProduct.Checked) ops.Add(OperationType.ProductSync);
            if (chkCustomer.Checked) ops.Add(OperationType.CustomerSync);
            UpdatedConfig.EnabledOperations = ops;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        private CheckBox chkCustomer;
        private Button btnSave;
    }
}