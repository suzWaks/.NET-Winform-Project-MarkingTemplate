using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkingTemplate
{
    public partial class Form2 : Form
    {
        public static Form2 instance; //Creating instance of form to pass data
        public Label LbName, LbDev, LbRating, LbPercentage; //To access via Form1

        private readonly string connstring;

        public Form2()
        {
            InitializeComponent();
            instance = this;      
            LbName = ResultName; //Connecting to the variable name
            LbDev = ResultDevLevel;
            LbRating = ratingValue;
            LbPercentage = FinalPercentage;

            connstring = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;  //Connection string from configuration
        }

        private void btnSaveToDB_Click(object sender, EventArgs e)
        {
            using (var sqlcon = new SqlConnection(connstring)) //using block ensures connection is closed after use (Dispose)
            {
                try
                {
                    sqlcon.Open(); // Opens the connection to the database.

                    using (var checkDb = new SqlCommand("checkResult", sqlcon)) //Check if user details already exists
                    {
                        checkDb.CommandType = CommandType.StoredProcedure;

                        checkDb.Parameters.AddWithValue("@Dev_Name", ResultName.Text);
                        checkDb.Parameters.AddWithValue("@Dev_Level", ResultDevLevel.Text);

                        var result = checkDb.ExecuteScalar(); // Execute the stored procedure; returns 1 if record exists, 0 otherwise
                        var checkExists = result != null ? Convert.ToInt32(result) : 0; 

                        if (checkExists == 1)
                        {
                            var option = MessageBox.Show("Record already exists for this person. Do you want to update the previous record?",
                                "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (option == DialogResult.Yes)
                            {
                                UpdateRecord(sqlcon);
                            }
                        }
                        else
                        {
                            InsertRecord(sqlcon);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to the database: " + ex.Message);
                }
            }
        }

        private void UpdateRecord(SqlConnection connection)
        {
            try
            {
                using (var cmd = new SqlCommand("updateResult", connection)) //Update results table in basis of Dev_Name and Dev_Level match
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the stored procedure
                    cmd.Parameters.AddWithValue("@Dev_Name", ResultName.Text);
                    cmd.Parameters.AddWithValue("@Dev_Level", ResultDevLevel.Text);
                    cmd.Parameters.AddWithValue("@Rating_Value", ratingValue.Text);
                    cmd.Parameters.AddWithValue("@Final_Percentage", FinalPercentage.Text);

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Results updated successfully ✅", "Successful update", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update record: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertRecord(SqlConnection connection)
        {
            try
            {
                using (var cmd = new SqlCommand("insertResult", connection)) // Stored procedure
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the stored procedure
                    cmd.Parameters.AddWithValue("@Dev_Name", ResultName.Text);
                    cmd.Parameters.AddWithValue("@Dev_Level", ResultDevLevel.Text);
                    cmd.Parameters.AddWithValue("@Rating_Value", ratingValue.Text);
                    cmd.Parameters.AddWithValue("@Final_Percentage", FinalPercentage.Text);

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Results inserted successfully ✅", "Successful insertion", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert record: " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
