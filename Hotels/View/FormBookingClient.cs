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
    public partial class FormBookingClient : Form
    {
        ControllerBooking controller;
        public FormBookingClient()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            Dictionary<string, ComboBox> comboBoxs = new Dictionary<string, ComboBox>();
            Dictionary<string, DateTimePicker> dateTimePickers = new Dictionary<string, DateTimePicker>();
            textBoxs.Add("Client", tbClient);
            comboBoxs.Add("Client", cbClient);
            comboBoxs.Add("Hotel", cbHotel);
            comboBoxs.Add("RoomType", cbRoomType);
            comboBoxs.Add("Room", cbRoom);
            dateTimePickers.Add("StartDate", dTPStart);
            dateTimePickers.Add("EndDate", dTPEnd);
            controller = new ControllerBooking(dgv, bnBooking, textBoxs, comboBoxs,dateTimePickers);
            controller.FillColumns();
        }

        private void FormBookingClient_Load(object sender, EventArgs e)
        {
            controller.LoadClientDB();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (controller.IsValid())
            {
                controller.Save();
                controller.LoadClientDB();
                MessageBox.Show("Номер забрьоновано", "Бронювання", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Дані введено не вірно", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Ви справді хочете видалити бронювання?",
            "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                controller.Delete();
                controller.LoadClientDB();
            }
        }

        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeHotel();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeRoomType();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
