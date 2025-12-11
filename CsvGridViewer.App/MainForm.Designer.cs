using System.Drawing;
using System.Windows.Forms;

namespace CsvGridViewer.App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;

        private Panel uploadPanel;
        private TableLayoutPanel uploadLayout;
        private Label labelUploadPrompt;
        private Button buttonUpload;

        private Panel bottomPanel;
        private TableLayoutPanel bottomLayout;
        private Button buttonBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            this.statusStrip1 = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel();

            this.uploadPanel = new Panel();
            this.uploadLayout = new TableLayoutPanel();
            this.labelUploadPrompt = new Label();
            this.buttonUpload = new Button();

            this.bottomPanel = new Panel();
            this.bottomLayout = new TableLayoutPanel();
            this.buttonBack = new Button();

            var headerStyle = new DataGridViewCellStyle();
            var defaultStyle = new DataGridViewCellStyle();
            var alternatingStyle = new DataGridViewCellStyle();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.uploadPanel.SuspendLayout();
            this.uploadLayout.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.bottomLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Dock = DockStyle.Fill;

            // Grid styling
            this.dataGridView1.BackgroundColor = Color.White;
            this.dataGridView1.BorderStyle = BorderStyle.None;
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Header style
            headerStyle.BackColor = Color.FromArgb(45, 45, 48);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dataGridView1.EnableHeadersVisualStyles = false;

            // Default cell style
            defaultStyle.BackColor = Color.White;
            defaultStyle.ForeColor = Color.Black;
            defaultStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            defaultStyle.SelectionForeColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.dataGridView1.DefaultCellStyle = defaultStyle;

            // Alternating rows
            alternatingStyle.BackColor = Color.FromArgb(245, 245, 245);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = alternatingStyle;

            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new ToolStripItem[] { this.statusLabel });
            this.statusStrip1.Dock = DockStyle.Bottom;
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new Size(160, 17);
            this.statusLabel.Text = "Please upload a .csv file.";
            // 
            // uploadPanel
            // 
            this.uploadPanel.Dock = DockStyle.Fill;
            this.uploadPanel.BackColor = Color.WhiteSmoke;
            this.uploadPanel.Controls.Add(this.uploadLayout);
            this.uploadPanel.Name = "uploadPanel";
            this.uploadPanel.TabIndex = 2;
            // 
            // uploadLayout
            // 
            this.uploadLayout.ColumnCount = 1;
            this.uploadLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.uploadLayout.RowCount = 3;
            this.uploadLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.uploadLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.uploadLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.uploadLayout.Dock = DockStyle.Fill;
            this.uploadLayout.Name = "uploadLayout";

            this.uploadLayout.Controls.Add(this.labelUploadPrompt, 0, 1);
            this.uploadLayout.Controls.Add(this.buttonUpload, 0, 2);
            // 
            // labelUploadPrompt
            // 
            this.labelUploadPrompt.Anchor = AnchorStyles.None;
            this.labelUploadPrompt.AutoSize = true;
            this.labelUploadPrompt.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.labelUploadPrompt.Name = "labelUploadPrompt";
            this.labelUploadPrompt.Text = "Please upload a .csv file";
            this.labelUploadPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonUpload
            // 
            this.buttonUpload.Anchor = AnchorStyles.None;
            this.buttonUpload.AutoSize = true;
            this.buttonUpload.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.buttonUpload.Margin = new Padding(0, 10, 0, 0);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new Size(120, 30);
            this.buttonUpload.Text = "Choose CSV file...";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Height = 50;
            this.bottomPanel.BackColor = Color.WhiteSmoke;
            this.bottomPanel.Padding = new Padding(0, 8, 0, 8); // gap between grid and button
            this.bottomPanel.Controls.Add(this.bottomLayout);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.TabIndex = 3;
            // 
            // bottomLayout
            // 
            this.bottomLayout.ColumnCount = 1;
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bottomLayout.Dock = DockStyle.Fill;
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.Controls.Add(this.buttonBack, 0, 0);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = AnchorStyles.None;
            this.buttonBack.AutoSize = true;
            this.buttonBack.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new Size(120, 27);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Upload new file";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.uploadPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.statusStrip1);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.MinimumSize = new Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "CSV Grid Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.uploadPanel.ResumeLayout(false);
            this.uploadLayout.ResumeLayout(false);
            this.uploadLayout.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomLayout.ResumeLayout(false);
            this.bottomLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
