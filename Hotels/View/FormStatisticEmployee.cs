using Hotels.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotels.View
{
    public partial class FormStatisticEmployee : Form
    {
        ControllerEmployee controller;
        public FormStatisticEmployee()
        {
            InitializeComponent();
            Dictionary<string, Chart> charts = new Dictionary<string, Chart>();
            charts.Add("Age", chartAge);
            charts.Add("Salary", chartSalary);
            controller = new ControllerEmployee(charts);
        }

        private void FormStatistic_Load(object sender, EventArgs e)
        {
            controller.DrawChart();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chartSalary_Click(object sender, EventArgs e)
        {

        }

        private void chartAge_Click(object sender, EventArgs e)
        {

        }
    }
}
