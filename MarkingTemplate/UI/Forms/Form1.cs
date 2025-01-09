using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkingTemplate.UI.Forms;

namespace MarkingTemplate

{
    public partial class MarkingTemplate : Form
    {
        //Creating objects of the classes
        Navigation nav = new Navigation();
        Computations comp = new Computations();
        FetchingComboBoxValue fetchComboBoxValue = new FetchingComboBoxValue(); //Fetching user chosen ranks from ComboBoxes
        LoadFromDb loadFromDb = new LoadFromDb(); //Loading data from DB

        List<double> rating = new List<double>(); //Storing rating (weightage) in each tab

        public static Form instance; //Singleton design pattern for global accessibility of the form

        public MarkingTemplate() 
        {
            InitializeComponent();
            instance = this;        //MarkingTemplate constructor assigns itself to the instance
        }

        //Key value pairs of TabIndex and respective control names
        Dictionary<int, TabControls> ControlMaps = new Dictionary<int, TabControls>();
        public void AddToControlMaps()
        {
            ControlMaps.Add(0, new TabControls //Structure defined in TabControl.cs
            {
                DataGrid = dataGridView1,
                AverageValueBox = avgValue,
                WeightageValue = Weight1,
                PercentageValueBox = perctValue,
                TitleLabel = label3, 
                Description = textBox2,

            });

            ControlMaps.Add(1, new TabControls
            {
                DataGrid = dataGridView2,
                AverageValueBox = AvgValue2,
                WeightageValue = Weight2,
                PercentageValueBox = PerctValue2,
                TitleLabel = label7,
                Description = textBox3,
            });

            ControlMaps.Add(2, new TabControls
            {
                DataGrid = dataGridView3,
                AverageValueBox = AvgValue3,
                WeightageValue = Weight3,
                PercentageValueBox = PerctValue3,
                TitleLabel = label11,
                Description = textBox1
            });

            ControlMaps.Add(3, new TabControls
            {
                DataGrid = dataGridView4,
                AverageValueBox = AvgValue4,
                WeightageValue = Weight4,
                PercentageValueBox = PerctValue4,
                TitleLabel = label4,
                Description = textBox4
            });

            ControlMaps.Add(4, new TabControls
            {
                DataGrid = dataGridView5,
                AverageValueBox = AvgValue5,
                WeightageValue = Weight5,
                PercentageValueBox = PerctValue5,
                TitleLabel = label8,
                Description = textBox5
            });

            ControlMaps.Add(5, new TabControls
            {
                DataGrid = dataGridView6,
                AverageValueBox = AvgValue6,
                WeightageValue = Weight6,
                PercentageValueBox = PerctValue6,
                TitleLabel = label14,
                Description = textBox6,
            });
        } //Adding control names to Dictionary


        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate the dictionary with the mappings
            AddToControlMaps();

            // Loop through all the tabs in the TabControl
            for (var i = 0; i < tabControl1.TabCount; i++)
            {
                // Retrieve data from DB (Category & SubCategory Table) for the current tab index
                var tabData = loadFromDb.LoadTabData(i + 1); //TabIndex+1 since stored procedure starts from 1
                tabControl1.TabPages[i].Text = tabData.CategoryId + ". " + tabData.LabelData; //Update tab title to match Title

                if (ControlMaps.TryGetValue(i, out var tabControls)) // Check if the mapping exists for the current tab
                {
                    LoadingTab LoadingTab = new LoadingTab();

                    LoadingTab.LoadControls(tabControls, tabData); // Dynamically load data into controls for the current tab
                }
            }

        }


        //Generating values on button click
        private void GenValue_Click(object sender, EventArgs e)
        {
            var tabIndex = tabControl1.SelectedIndex;

            if (ControlMaps.TryGetValue(tabIndex, out var controls))
            {
                if (controls.AverageValueBox.Text != "value" && controls.PercentageValueBox.Text != "value in %") //Dont allow double calculation of values
                {
                    MessageBox.Show("Values already generated. Please proceed to next tab",
                        "Invalid action Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var weightage = 0.0;
                foreach (DataGridViewRow row in controls.DataGrid.Rows)
                {
                    

                    var weightValue = controls.WeightageValue.Text;

                    //TODO: Uncomment while not testing
                    //var selectedValues = fetchComboBoxValue.GetSelectedComboBoxValues(controls.DataGrid);

                    //TODO: Dummy values for testing purposes
                    var selectedValues = new List<string>();
                    selectedValues.Add("1");
                    selectedValues.Add("2");
                    selectedValues.Add("3");

                    // Check for null or empty values in ComboBox selections
                    if (selectedValues.Any(string.IsNullOrEmpty)) //LINQ;if at least one element satisfies the condition
                        {
                            MessageBox.Show("Please ensure all ComboBox values are selected before proceeding.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    // Convert string list to integer list
                    var selectedIntegers = selectedValues.Select(int.Parse).ToList();

                    // Calculate and display average
                    controls.AverageValueBox.Text = comp.Average(selectedIntegers).ToString("F2");

                    // Calculate and display percentage
                    weightage = comp.Percentage(selectedIntegers, weightValue);
                    controls.PercentageValueBox.Text = weightage.ToString("F2");
                }
                // Add to ratings list for end computation
                rating.Add(weightage);
            }
        }


        //Next & Prev. Button
        private void NextBtn_Click_1(object sender, EventArgs e)
        {
            // Check if the user has generated values before proceeding
            var tabIndex = tabControl1.SelectedIndex;
            if (ControlMaps.TryGetValue(tabIndex, out TabControls controls))
            {
                if (controls.AverageValueBox.Text == "value" && controls.PercentageValueBox.Text == "value in %") //Values not generated and the placeholder texts exist
                {
                    MessageBox.Show("Please ensure you generate values before proceeding.", "Incomplete Action Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            nav.NavigateTabs(1, tabControl1);

        }
        private void PrevBtn_Click(object sender, EventArgs e)
        {
            nav.NavigateTabs(-1, tabControl1);
        }


        //Opening Form2 by passing results from Form1 and performing calculations
        private void FinalResult_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            var ratingValue = 0.00;

            //Passing data to form 2
            if (!string.IsNullOrWhiteSpace(NameField.Text) || !string.IsNullOrWhiteSpace(devDrop.Text))
            {
                Form2.instance.LbName.Text = NameField.Text; 
                Form2.instance.LbDev.Text = devDrop.Text;

            }
            else
            {
                MessageBox.Show("Make sure you have chosen developer level and entered the name",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            if (rating.Count < tabControl1.TabCount)
            {
                MessageBox.Show("Make sure you have generated all the values in all tabs",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ratingValue = rating.Sum();
                Form2.instance.LbRating.Text = ratingValue.ToString("F2");
            }
            

            var devWeightage = 0.0;

            switch (devDrop.Text) //Calculation of overall percentage (multiplied by dev weightage)
            {
                case ("Junior-Dev"):
                    devWeightage = 1.5;

                    Form2.instance.LbPercentage.Text = ((ratingValue / devWeightage)*100).ToString("F1");
                    break; 
                
                case ("Mid-Dev"):
                    devWeightage = 2.5;

                    Form2.instance.LbPercentage.Text = ((ratingValue / devWeightage) * 100).ToString("F1");
                    break;

                case ("Senior-Dev"):
                    devWeightage = 3;

                    Form2.instance.LbPercentage.Text = ((ratingValue / devWeightage) * 100).ToString("F1");
                    break;
            }
            form.Show();
        }

        private void btnResultsView_Click_1(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.Show();
        }
    }
}
