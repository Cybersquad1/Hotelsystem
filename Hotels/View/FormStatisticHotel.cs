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

namespace Hotels.View
{
    public partial class FormStatisticHotel : Form
    {
        ControllerHotel controller;
        public FormStatisticHotel()
        {
            InitializeComponent();
            controller = new ControllerHotel(chartHotel, cbHotel, dtpDate);
        }

        private void FormStatisticHotel_Load(object sender, EventArgs e)
        {
            controller.DrawChart();
        }

        private void cbHotel_SelectedValueChanged(object sender, EventArgs e)
        {
            controller.ChangeHotel();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeHotel();
        }
    }
}
