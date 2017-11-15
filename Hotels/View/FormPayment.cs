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
    public partial class FormPayment : Form
    {
        ControllerPayment controller;
        public FormPayment()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            Dictionary<string, Label> labels = new Dictionary<string, Label>();
            textBoxs.Add("Search",tbSearch);
            textBoxs.Add("Amount", tbAmount);
            labels.Add("Amount", lbAmout);
            labels.Add("Remainder", lbRemainder);
            controller = new ControllerPayment(rtbInfo, textBoxs, labels);
        }
        private void FormPayment_Load(object sender, EventArgs e)
        {
            tbSearch.Text = "9";
            lbAmout.Text = "";
            lbRemainder.Text = "";
            controller.LoadDB();
            controller.GetInfo();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            controller.LoadDB();
            controller.GetInfo();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            controller.Save();
            controller.LoadDB();
            controller.GetInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbAmout_Click(object sender, EventArgs e)
        {

        }
    }
}
