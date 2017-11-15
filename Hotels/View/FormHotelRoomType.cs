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
    public partial class FormHotelRoomType : Form
    {
        ControllerHotelRoomType controller;
        public FormHotelRoomType()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            
            controller = new ControllerHotelRoomType(dgv, bNav, textBoxs, cbHotel, cbRoomType);
            controller.FillColumns();
        }

        private void FormHotelRoomType_Load(object sender, EventArgs e)
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
            DialogResult dialog = MessageBox.Show("Ви справді хочете видалити тип кімнати з готелю?",
            "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                controller.Delete();
                controller.LoadDB();
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            controller.Add();
        }

        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeHotel();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
