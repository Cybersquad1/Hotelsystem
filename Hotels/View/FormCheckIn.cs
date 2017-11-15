using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotels.Controller;

namespace Hotels.View
{
    public partial class FormCheckIn : Form
    {
        ControllerCkeckIn controller;
        public FormCheckIn()
        {
            InitializeComponent();
            controller = new ControllerCkeckIn(rtbInfo, tbSearch);
        }

        private void FormCheckIn_Load(object sender, EventArgs e)
        {
            controller.LoadDB();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            controller.GetInfo();
        }
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            controller.CheckIn();
            controller.GetInfo();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            controller.CheckOut();
            controller.GetInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
