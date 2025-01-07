using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkingTemplate
{
    public static class DataGridColumn
    {
        public static void InitializeCols(DataTable table, DataGridViewComboBoxColumn comboBoxColumn)
        {

            // Create a ComboBox column separately since we need to allow modification
            comboBoxColumn.HeaderText = "Rating";
            comboBoxColumn.Name = "Rating";

            comboBoxColumn.Items.Add("1");
            comboBoxColumn.Items.Add("2");
            comboBoxColumn.Items.Add("3");


        }
    }
}
