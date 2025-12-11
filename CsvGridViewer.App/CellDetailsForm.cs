using System;
using System.Windows.Forms;

namespace CsvGridViewer.App
{
    public partial class CellDetailsForm : Form
    {
        public CellDetailsForm(string cellValue)
        {
            InitializeComponent();
            textBoxValue.Text = cellValue ?? string.Empty;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
