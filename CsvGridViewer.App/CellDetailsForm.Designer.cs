using System.Drawing;
using System.Windows.Forms;

namespace CsvGridViewer.App
{
    partial class CellDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelCaption;
        private TextBox textBoxValue;
        private Button buttonClose;

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
            this.labelCaption = new Label();
            this.textBoxValue = new TextBox();
            this.buttonClose = new Button();
            this.SuspendLayout();
            // 
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
            this.labelCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.labelCaption.Location = new Point(12, 12);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new Size(68, 15);
            this.labelCaption.TabIndex = 0;
            this.labelCaption.Text = "Cell value:";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.textBoxValue.Location = new Point(12, 32);
            this.textBoxValue.Multiline = true;
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.ScrollBars = ScrollBars.Vertical;
            this.textBoxValue.Size = new Size(360, 120);
            this.textBoxValue.TabIndex = 1;
            this.textBoxValue.BorderStyle = BorderStyle.FixedSingle;
            this.textBoxValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonClose.Location = new Point(297, 165);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(75, 27);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CellDetailsForm
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(384, 204);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.labelCaption);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CellDetailsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cell Details";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
