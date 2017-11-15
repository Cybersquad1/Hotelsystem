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
    public partial class FormRoom : Form
    {
        ControllerRoom controller;
        bool add = true;
        public FormRoom()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            textBoxs.Add("Name", tbName);
            controller = new ControllerRoom(dgvRoom, bindingNavigatorRoom, textBoxs,cbHotel,cbRoomType);
            controller.FillColumns();
        }

        private void FormRoom_Load(object sender, EventArgs e)
        {
           controller.LoadDB();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            add = true;
            controller.Add();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            controller.Save();
            controller.LoadDB();
            add = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ви справді хочете видалити кімнату?",
            "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                controller.Delete();
                controller.LoadDB();
            }
        }

        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!add)
                controller.ChangeHotel();
            add = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeRoomType();
        }
    }
}
