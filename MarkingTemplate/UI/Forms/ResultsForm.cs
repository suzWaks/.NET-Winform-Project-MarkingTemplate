using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MarkingTemplate.UI.Forms
{
    public partial class ResultsForm : Form
    {
        private readonly string connstring;

        public ResultsForm()
        {
            InitializeComponent();
            connstring =
                ConfigurationManager.ConnectionStrings["myconn"]
                    .ConnectionString; //Connection string from configuration

            LoadData();
        }

        private void LoadData()
        {
            using (var sqlcon = new SqlConnection(connstring)) //using block ensures connection is closed after use (Dispose)
            {
                try
                {
                    sqlcon.Open(); // Opens the connection to the database.

                    using (var cmd = new SqlCommand("getResults", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var reader = cmd.ExecuteReader())
                        {
                            // Read data into the TabData object
                            if (reader.HasRows)
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader); // Load data from SqlDataReader into the DataTable

                                // Bind the DataTable to the DataGridView
                                resultsDataGrid.DataSource = dataTable;

                                noDataLabels.Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to the database: " + ex.Message);
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (resultsDataGrid.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to write data in disk: " + ex.Message);
                        }
                    }

                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(resultsDataGrid.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;


                            // Add headers
                            foreach (DataGridViewColumn col in resultsDataGrid.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            // Add data with null checking
                            foreach (DataGridViewRow viewRow in resultsDataGrid.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    string cellValue = dcell.Value?.ToString() ?? string.Empty;
                                    pTable.AddCell(cellValue);
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                            }

                            MessageBox.Show("Data exported successfully", "Success");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting data: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No records found", "Info");
            }
        }

    }
}
