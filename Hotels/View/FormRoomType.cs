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
    public partial class FormRoomType : Form
    {
        ControllerRoomType controller;
        public FormRoomType()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            textBoxs.Add("Name", tbName);
            textBoxs.Add("Price", tbPrice);
            textBoxs.Add("MaxPerson", tbMaxPerson);
            controller = new ControllerRoomType(dgvRoomType, bindingNavigatorRoomType, textBoxs, rtbDescription);
            controller.FillColumns();
        }

        private void FormRoomType_Load(object sender, EventArgs e)
        {
            controller.LoadDB();
            //rtbDescription.Text = "ddddddddddd";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            controller.Save();
            controller.LoadDB();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ви справді хочете видалити тип кімнати?",
            "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    }
}
