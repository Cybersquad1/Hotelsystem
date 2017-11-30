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
    public partial class FormHotelEmployee : Form
    {
        ControllerHotelEmployee controller;
        public FormHotelEmployee()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();

            controller = new ControllerHotelEmployee(dgv, bNav, textBoxs, cbHotel, cbEmployee);
            controller.FillColumns();
        }

        private void FormHotelEmployee_Load(object sender, EventArgs e)
        {
            controller.LoadDB();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            controller.Save();
            controller.LoadDB();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you really want to remove an employee from the hotel?",
            "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                controller.Delete();
                controller.LoadDB();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeHotel();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            controller.Add();
        }
    }
}
