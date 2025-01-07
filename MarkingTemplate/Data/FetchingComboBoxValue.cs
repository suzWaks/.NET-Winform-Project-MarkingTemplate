using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarkingTemplate
{
    internal class FetchingComboBoxValue
    {
        public List<string> GetSelectedComboBoxValues(DataGridView dataGridView)
        {
            // List to store selected values
            var selectedValues = new List<string>();

            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // Check if the row is not null and has a "Rating" cell
                    if (row.Cells["Rating"] is DataGridViewComboBoxCell comboBoxCell)
                    {
                        // Get the selected value
                        selectedValues.Add(comboBoxCell.Value as string);

                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                // Handle case where column "Rating" doesn't exist
                MessageBox.Show($"Column 'Rating' not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return selectedValues;
        }
    }
}