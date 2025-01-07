using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace MarkingTemplate
{
    //Load the retrieved data into the controls
    public class LoadingTab 
    {
        private readonly DataGridViewComboBoxColumn _comboBoxColumn = new DataGridViewComboBoxColumn();
        LoadFromDb loadFromDb = new LoadFromDb(); //Loading data from DB

        public void LoadControls(TabControls controls, TabData data)
        {
            // Update title
            controls.TitleLabel.Text = data.CategoryId + ". " + data.LabelData;

            // Update description
            controls.Description.Text = data.TextBoxData;

            // Update weight
            controls.WeightageValue.Text = data.WeightBox;
            
            // Bind the data from SubCategory Table to the DataGridView
            controls.DataGrid.DataSource = data.TableData;

            //Styling the datagridview
            controls.DataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True; //Multiline property
            controls.DataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            controls.DataGrid.Columns["SubCategory_Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            controls.DataGrid.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;



            // Ensure 'details' column exists in the DataTable for data from Details table
            if (!data.TableData.Columns.Contains("Details"))
            {
                data.TableData.Columns.Add("Details", typeof(string)); // Add column to DataTable
            }

            // Update 'details' column values for each row
            foreach (DataRow row in data.TableData.Rows)
            {
                try
                {
                    double subCat = Convert.ToDouble(row[0]); //First column is SubCategory_Id; Foreign key to Details Table
                    var details = loadFromDb.DetailsData(subCat); //Retrieve details based on SubCategory_Id

                    // Join all details in the list into a single string
                    string combinedDetails = string.Join(Environment.NewLine, details);
                    row["Details"] = combinedDetails; // Update 'Details' column in the DataTable
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing row: {ex.Message}");
                    row["Details"] = string.Empty;
                }
            }

            // Add combo box column for rating dropdown
            if (!controls.DataGrid.Columns.Contains(_comboBoxColumn.Name))
            {
                DataGridColumn.InitializeCols(data.TableData, _comboBoxColumn); // Initialize dropdown options
                controls.DataGrid.Columns.Add(_comboBoxColumn);
                controls.DataGrid.Columns["Rating"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }


    }
}