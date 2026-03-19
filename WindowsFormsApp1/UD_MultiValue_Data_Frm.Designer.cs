using System.Drawing;
using System.Windows.Forms;

namespace UD_MV_DataHandler
{
    partial class UD_MultiValue_Data_Frm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private TabPage tabOrders;
        private TabPage tabClients;
        private TabPage tabInventory;
        private DataGridView dgvOrders;
        private DataGridView dgvClients;
        private DataGridView dgvInventory;
        private TextBox txtOrderId;
        private Button btnLoadOrders;
        private TextBox txtClientSearch;
        private Button btnSearchClients;
        private TextBox txtInventorySearch;
        private Button btnLoadInventory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabOrders = new TabPage();
            dgvOrders = new DataGridView();
            txtOrderId = new TextBox();
            btnLoadOrders = new Button();
            tabClients = new TabPage();
            dgvClients = new DataGridView();
            txtClientSearch = new TextBox();
            btnSearchClients = new Button();
            tabInventory = new TabPage();
            dgvInventory = new DataGridView();
            btnLoadInventory = new Button();
            txtInventorySearch = new TextBox();

            tabControl.SuspendLayout();
            tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            tabClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            tabInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();

            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabOrders);
            tabControl.Controls.Add(tabClients);
            tabControl.Controls.Add(tabInventory);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 450);
            tabControl.TabIndex = 0;
            tabControl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            tabControl.BackColor = Color.WhiteSmoke;

            // 
            // tabOrders
            // 
            tabOrders.Controls.Add(dgvOrders);
            tabOrders.Controls.Add(txtOrderId);
            tabOrders.Controls.Add(btnLoadOrders);
            tabOrders.Location = new Point(4, 29);
            tabOrders.Name = "tabOrders";
            tabOrders.Size = new Size(792, 417);
            tabOrders.TabIndex = 0;
            tabOrders.Text = "Orders";
            tabOrders.BackColor = Color.White;

            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeight = 29;
            dgvOrders.Location = new Point(10, 68);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(760, 322);
            dgvOrders.TabIndex = 0;

            // Uniform DataGridView Style
            ApplyGridStyle(dgvOrders);

            // 
            // txtOrderId
            // 
            txtOrderId.Location = new Point(8, 20);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new Size(200, 27);
            txtOrderId.TabIndex = 1;
            txtOrderId.Font = new Font("Segoe UI", 9);

            // 
            // btnLoadOrders
            // 
            btnLoadOrders.Location = new Point(214, 15);
            btnLoadOrders.Name = "btnLoadOrders";
            btnLoadOrders.Size = new Size(120, 37);
            btnLoadOrders.TabIndex = 2;
            btnLoadOrders.Text = "Load Orders";
            btnLoadOrders.Click += btnLoadOrders_Click;
            btnLoadOrders.BackColor = Color.DarkSlateBlue;
            btnLoadOrders.ForeColor = Color.White;
            btnLoadOrders.FlatStyle = FlatStyle.Flat;
            btnLoadOrders.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // 
            // tabClients
            // 
            tabClients.Controls.Add(dgvClients);
            tabClients.Controls.Add(txtClientSearch);
            tabClients.Controls.Add(btnSearchClients);
            tabClients.Location = new Point(4, 29);
            tabClients.Name = "tabClients";
            tabClients.Size = new Size(792, 417);
            tabClients.TabIndex = 1;
            tabClients.Text = "Customers";
            tabClients.BackColor = Color.White;

            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeight = 29;
            dgvClients.Location = new Point(10, 65);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(760, 325);
            dgvClients.TabIndex = 0;

            // Uniform DataGridView Style
            ApplyGridStyle(dgvClients);

            // 
            // txtClientSearch
            // 
            txtClientSearch.Location = new Point(8, 16);
            txtClientSearch.Name = "txtClientSearch";
            txtClientSearch.Size = new Size(200, 27);
            txtClientSearch.TabIndex = 1;
            txtClientSearch.Font = new Font("Segoe UI", 9);

            // 
            // btnSearchClients
            // 
            btnSearchClients.Location = new Point(220, 10);
            btnSearchClients.Name = "btnSearchClients";
            btnSearchClients.Size = new Size(120, 39);
            btnSearchClients.TabIndex = 2;
            btnSearchClients.Text = "Search Customer";
            btnSearchClients.Click += btnSearchClients_Click;
            btnSearchClients.BackColor = Color.DarkSlateBlue;
            btnSearchClients.ForeColor = Color.White;
            btnSearchClients.FlatStyle = FlatStyle.Flat;
            btnSearchClients.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // 
            // tabInventory
            // 
            tabInventory.Controls.Add(txtInventorySearch);
            tabInventory.Controls.Add(dgvInventory);
            tabInventory.Controls.Add(btnLoadInventory);
            tabInventory.Location = new Point(4, 29);
            tabInventory.Name = "tabInventory";
            tabInventory.Size = new Size(792, 417);
            tabInventory.TabIndex = 2;
            tabInventory.Text = "Inventory";
            tabInventory.BackColor = Color.White;

            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeight = 29;
            dgvInventory.Location = new Point(10, 62);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new Size(760, 328);
            dgvInventory.TabIndex = 0;

            // Uniform DataGridView Style
            ApplyGridStyle(dgvInventory);

            // 
            // btnLoadInventory
            // 
            btnLoadInventory.Location = new Point(216, 13);
            btnLoadInventory.Name = "btnLoadInventory";
            btnLoadInventory.Size = new Size(136, 32);
            btnLoadInventory.TabIndex = 1;
            btnLoadInventory.Text = "Load Inventory";
            btnLoadInventory.Click += btnLoadInventory_Click;
            btnLoadInventory.BackColor = Color.DarkSlateBlue;
            btnLoadInventory.ForeColor = Color.White;
            btnLoadInventory.FlatStyle = FlatStyle.Flat;
            btnLoadInventory.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // 
            // txtInventorySearch
            // 
            txtInventorySearch.Location = new Point(8, 16);
            txtInventorySearch.Name = "txtInventorySearch";
            txtInventorySearch.Size = new Size(200, 27);
            txtInventorySearch.TabIndex = 2;
            txtInventorySearch.Font = new Font("Segoe UI", 9);

            // 
            // Inv_Data_Project
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Name = "Inv_Data_Project";
            Text = "UniData Inventory Data Tracker";
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 9);

            tabControl.ResumeLayout(false);
            tabOrders.ResumeLayout(false);
            tabOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            tabClients.ResumeLayout(false);
            tabClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            tabInventory.ResumeLayout(false);
            tabInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
        }

        // Helper method for uniform DataGridView styling
        private void ApplyGridStyle(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            grid.GridColor = Color.DarkGray;
            grid.BorderStyle = BorderStyle.Fixed3D;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
