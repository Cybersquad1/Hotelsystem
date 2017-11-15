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
    public partial class FormBookingMake : Form
    {
        ControllerBooking controller;
        public FormBookingMake() 
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            Dictionary<string, ComboBox> comboBoxs = new Dictionary<string, ComboBox>();
            Dictionary<string, DateTimePicker> dateTimePickers = new Dictionary<string, DateTimePicker>();
            comboBoxs.Add("Hotel", cbHotel);
            comboBoxs.Add("RoomType", cbRoomType);
            comboBoxs.Add("Room", cbRoom);
            dateTimePickers.Add("StartDate", dTPStart);
            dateTimePickers.Add("EndDate", dTPEnd);
            controller = new ControllerBooking(textBoxs, comboBoxs, dateTimePickers,labelTotal);
        }

        private void FormBookingMake_Load(object sender, EventArgs e)
        {
            controller.FillForm();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (controller.IsValid())
            {
                controller.SaveUserBooking();
                MessageBox.Show("Номер забрьоновано", "Бронювання", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Дані введено не вірно", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeHotel();
            controller.GetTotal();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeRoomType();
            controller.GetTotal();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dTPStart_ValueChanged(object sender, EventArgs e)
        {
            controller.GetTotal();
        }

        private void dTPEnd_ValueChanged(object sender, EventArgs e)
        {
            controller.GetTotal();
        }
    }
}
