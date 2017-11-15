using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Hotels.Model;
using Hotels.Controller;
using Hotels.View;

namespace Hotels
{
    public partial class FormMain : Form
    {
        //public static Person СurrentUser;
        public ControllerMain controller;
        public ControllerProfile controllerProfile;
        public FormMain()
        {
            InitializeComponent();
            Dictionary<string, ToolStripMenuItem> menuItems = new Dictionary<string, ToolStripMenuItem>();
            menuItems.Add("Dictionary", itemDictionary);
            menuItems.Add("Booking", itemBooking);
            menuItems.Add("Statistic", itemStatistic);
            menuItems.Add("Setting", itemSetting);
            menuItems.Add("CheckIn", itemCheckIn);
            menuItems.Add("Payment", itemPayment);
            menuItems.Add("BookingAll", itemBookingAll);
            controller = new ControllerMain(menuItems);
            controllerProfile = new ControllerProfile();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (controllerProfile.Authentication())
            {
                controller.AccessLevel(ControllerProfile.User);
                MessageBox.Show("Good day,  " + ControllerProfile.User.Login, "Authorization was successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FormLogin formLogin = new FormLogin();
                formLogin.MdiParent = this;
                formLogin.Show();
            }
        }

        private void itemPerson_Click(object sender, EventArgs e)
        {
            FormPerson formperson = new FormPerson();
            formperson.MdiParent = this;
            formperson.Show();
        }

        private void itemHotels_Click(object sender, EventArgs e)
        {
            FormHotel formhotel = new FormHotel();
            formhotel.MdiParent = this;
            formhotel.Show();
        }

        private void itemRoomType_Click(object sender, EventArgs e)
        {
            FormRoomType formRoomType = new FormRoomType();
            formRoomType.MdiParent = this;
            formRoomType.Show();
        }

        private void itemRoom_Click(object sender, EventArgs e)
        {
            FormRoom formRoom = new FormRoom();
            formRoom.MdiParent = this;
            formRoom.Show();
        }

        private void itemBooking_Click(object sender, EventArgs e)
        {
            FormBooking formBooking = new FormBooking();
            formBooking.MdiParent = this;
            formBooking.Show();
        }

        private void itemEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee formEmployee = new FormEmployee();
            formEmployee.MdiParent = this;
            formEmployee.Show();
        }

        private void itemHotelRoomType_Click(object sender, EventArgs e)
        {
            FormHotelRoomType form = new FormHotelRoomType();
            form.MdiParent = this;
            form.Show();
        }

        private void itemRefresh_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.MdiParent = this;
            formLogin.Show();
        }

        private void itemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void itemAboutProgram_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.MdiParent = this;
            form.Show();
        }

        private void itemMakeBooking_Click(object sender, EventArgs e)
        {
            FormBookingMake form = new FormBookingMake();
            form.MdiParent = this;
            form.Show();
        }

        private void itemMyBooking_Click(object sender, EventArgs e)
        {
            FormBookingClient form = new FormBookingClient();
            form.MdiParent = this;
            form.Show();
        }
        private void itemCheckIn_Click(object sender, EventArgs e)
        {
            FormCheckIn form = new FormCheckIn();
            form.MdiParent = this;
            form.Show();
        }
        bool exitfirst = true;
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitfirst)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to quit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    exitfirst = false;
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
                Application.Exit();
        }


        private void itemSettingHotels_Click(object sender, EventArgs e)
        {
            FormHotel form = new FormHotel();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingTypeRooms_Click(object sender, EventArgs e)
        {
            FormRoomType form = new FormRoomType();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingRooms_Click(object sender, EventArgs e)
        {
            FormRoom form = new FormRoom();
            form.MdiParent = this;
            form.Show();
        }

        private void itemPayment_Click(object sender, EventArgs e)
        {
            FormPayment form = new FormPayment();
            form.MdiParent = this;
            form.Show();
        }

        private void itemDictionaryHotelEmployee_Click(object sender, EventArgs e)
        {
            FormHotelEmployee form = new FormHotelEmployee();
            form.MdiParent = this;
            form.Show();
        }

        private void itemStatisticEmployee_Click(object sender, EventArgs e)
        {
            FormStatisticEmployee form = new FormStatisticEmployee();
            form.MdiParent = this;
            form.Show();
        }

        private void itemStatisticHotel_Click(object sender, EventArgs e)
        {
            FormStatisticHotel form = new FormStatisticHotel();
            form.MdiParent = this;
            form.Show();
        }

        private void itemProfile_Click(object sender, EventArgs e)
        {
            FormProfile form = new FormProfile();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingHotelList_Click(object sender, EventArgs e)
        {
            FormHotel form = new FormHotel();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingHotelRoom_Click(object sender, EventArgs e)
        {
            FormHotelRoomType form = new FormHotelRoomType();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingHotelEmployee_Click(object sender, EventArgs e)
        {
            FormHotelEmployee form = new FormHotelEmployee();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingPerson_Click(object sender, EventArgs e)
        {
            FormPerson form = new FormPerson();
            form.MdiParent = this;
            form.Show();
        }

        private void itemBookingAll_Click(object sender, EventArgs e)
        {
            FormBooking form = new FormBooking();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingPersonAll_Click(object sender, EventArgs e)
        {
            FormPerson form = new FormPerson();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingPersonEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee form = new FormEmployee();
            form.MdiParent = this;
            form.Show();
        }

        private void itemSettingClient_Click(object sender, EventArgs e)
        {
            FormClient form = new FormClient();
            form.MdiParent = this;
            form.Show();
        }

       

        
    }
}
