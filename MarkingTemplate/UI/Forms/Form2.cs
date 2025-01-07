using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkingTemplate
{
    public partial class Form2 : Form
    {
        public static Form2 instance; //Creating instance of form to pass data
        public Label LbName, LbDev, LbRating, LbPercentage; //To access via Form1
        public Form2()
        {
            InitializeComponent();
            instance =this;
            LbName = ResultName; //Connecting to the variable name
            LbDev = ResultDevLevel;

            LbRating = ratingValue;
            LbPercentage = FinalPercentage;
        }
    }
}
