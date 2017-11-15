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
    public partial class FormClient : Form
    {
        ControllerClient controller;
        public FormClient()
        {
            InitializeComponent();
            controller = new ControllerClient(dgv, bn);
            controller.FillColumns();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            controller.LoadDB();
        }
    }
}
