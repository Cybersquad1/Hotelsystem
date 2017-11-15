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
    public partial class FormBooking : Form
    {
        ControllerBooking controller;
        bool add = true;
        public FormBooking()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            Dictionary<string, ComboBox> comboBoxs = new Dictionary<string, ComboBox>();
            Dictionary<string, DateTimePicker> dateTimePickers = new Dictionary<string, DateTimePicker>();
            //textBoxs.Add("Name", tbName);
            comboBoxs.Add("Client", cbClient);
            comboBoxs.Add("Hotel", cbHotel);
            comboBoxs.Add("RoomType", cbRoomType);
            comboBoxs.Add("Room", cbRoom);
            dateTimePickers.Add("StartDate",dTPStart);
            dateTimePickers.Add("EndDate", dTPEnd);
            controller = new ControllerBooking(dgv, bnBooking, textBoxs, comboBoxs, dateTimePickers);
            controller.FillColumns();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            controller.Save();
            controller.LoadDB();
            add = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            controller.Delete();
            controller.LoadDB();

        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            controller.LoadDB();
        }

        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!add)
            controller.ChangeHotel();
            add = false;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            add = true;
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeRoomType();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveFirstItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
