using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MarkingTemplate
{
    public class LoadFromDb
    {
        // Connection string to the database; retrieved from App.config
        private readonly string connstring = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;

        //TabData gets retrieved from Category Table
        public TabData LoadTabData(int tabIndex)
        {
            var tabData = new TabData //Initialize TabData object with default values
            {
                TableData = new DataTable(),
                CategoryId = string.Empty,
                LabelData = string.Empty,
                TextBoxData = string.Empty,
                WeightBox = string.Empty
            };

            using (var sqlcon = new SqlConnection(connstring)) //Connection to SQL Server DB with connection details in connstring; using block ensures connection is closed after use (Dispose)
            {
                sqlcon.Open(); // Opens the connection to the database.
                using (var cmd = new SqlCommand("getData2", sqlcon)) // Stored procedure
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add a parameter to filter data based on the tab index
                    cmd.Parameters.AddWithValue("@TabIndex", tabIndex);

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Read data into the TabData object
                        if (reader.HasRows)
                        {
                            if (reader.Read()) //Read first row from the result set
                            {
                                tabData.CategoryId = reader["Category_Id"].ToString();
                                tabData.LabelData = reader["TItle"].ToString();
                                tabData.TextBoxData = reader["Description"].ToString();
                                tabData.WeightBox = reader["Weight"].ToString();
                            }

                            if (reader.NextResult()) //Executes next stored procedure in the result set
                            {
                                tabData.TableData.Load(reader); // Load category data (Category Table) into DataTable
                            }

                        }
                    }
                }
            }

            return tabData; //Populated TabData object
        }


        public List<string> DetailsData(double SubCat_Id)
        {
            List<string> details = new List<string>();
            using (var sqlcon = new SqlConnection(connstring))
            {
                sqlcon.Open();
                using (var cmd = new SqlCommand("getDetails", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubCat_Id", SubCat_Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string text = reader["Text"].ToString(); //Stored procedure returns 'Text' column from Details Table
                                details.Add(text);
                            }
                        }
                    }
                }
            }
            return details;
        }

    }


    public class TabData
    {
        public DataTable TableData { get; set; }
        public string LabelData { get; set; }
        public string CategoryId { get; set; }
        public string TextBoxData { get; set; }
        public string WeightBox { get; set; }
    }

}