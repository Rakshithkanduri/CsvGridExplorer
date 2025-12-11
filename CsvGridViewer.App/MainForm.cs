using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CsvGridViewer.Core.Services;

namespace CsvGridViewer.App
{
    /// <summary>
    /// Main application window that allows users to upload a CSV file
    /// and view its content in a grid.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ICsvParser _csvParser;
        private readonly ILoggingService _logger;
        private readonly string? _initialDirectory;

        public MainForm(ICsvParser csvParser, ILoggingService logger, string? initialDirectory = null)
        {
            _csvParser = csvParser ?? throw new ArgumentNullException(nameof(csvParser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _initialDirectory = initialDirectory;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            uploadPanel.Visible = true;

            // bottom panel and button are only visible after a CSV is loaded
            bottomPanel.Visible = false;
            buttonBack.Visible = false;

            statusLabel.Text = "Please upload a .csv file.";
        }

        private void LoadCsv(string filePath)
        {
            try
            {
                _logger.LogInfo($"Loading CSV file from '{filePath}'.");

                DataTable table = _csvParser.ParseFromFile(filePath);
                dataGridView1.DataSource = table;

                dataGridView1.Visible = true;
                uploadPanel.Visible = false;

                // show bottom panel + button when a CSV is successfully loaded
                bottomPanel.Visible = true;
                buttonBack.Visible = true;

                string fileName = Path.GetFileName(filePath);
                statusLabel.Text = $"Loaded: {fileName} ({table.Rows.Count} rows)";
                _logger.LogInfo("CSV file loaded successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to load CSV data from '{filePath}'.", ex);

                MessageBox.Show(
                    "Unable to load the CSV data. Please check that the selected file exists and is a valid CSV."
                    + Environment.NewLine +
                    "Details have been logged to your Desktop log file.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                using var dialog = new OpenFileDialog
                {
                    Title = "Select CSV file",
                    Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                };

                if (!string.IsNullOrWhiteSpace(_initialDirectory) && Directory.Exists(_initialDirectory))
                {
                    dialog.InitialDirectory = _initialDirectory;
                }
                else
                {
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCsv(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while opening CSV file dialog.", ex);

                MessageBox.Show(
                    "An error occurred while selecting the CSV file."
                    + Environment.NewLine +
                    "Please see the Desktop log file for details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }

                var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                string value = cell?.Value?.ToString() ?? string.Empty;

                using var detailsForm = new CellDetailsForm(value)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                detailsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while handling cell double-click.", ex);

                MessageBox.Show(
                    "An error occurred while opening the cell details window."
                    + Environment.NewLine +
                    "Please see the Desktop log file for details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInfo("Resetting view to allow uploading a new CSV file.");

                dataGridView1.DataSource = null;
                dataGridView1.Visible = false;
                uploadPanel.Visible = true;

                bottomPanel.Visible = false;
                buttonBack.Visible = false;

                statusLabel.Text = "Please upload a .csv file.";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while resetting the view for a new CSV upload.", ex);

                MessageBox.Show(
                    "An error occurred while resetting the view."
                    + Environment.NewLine +
                    "Please see the Desktop log file for details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
