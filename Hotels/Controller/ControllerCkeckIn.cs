using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerCkeckIn : Controller<Booking>
    {
        private RichTextBox richTextBox;
        private TextBox textBox;
        private Booking currentBooking;

        public ControllerCkeckIn(RichTextBox RichTextBox, TextBox TextBox)
        {
            richTextBox = RichTextBox; textBox = TextBox;
        }


        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public override void LoadDB()
        {
            new Booking().Get();
            new Person().Get();
            new Client().Get();
            new Room().Get();
            new RoomType().Get();
            new Hotel().Get();
            new HotelRoomType().Get();
        }

        public override void Save()
        {
            try
            {
                currentBooking.UpdateStatus();
                if(currentBooking.GetStatus() == "CheckIn")
                    MessageBox.Show("Client Checked-in", "Check-in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (currentBooking.GetStatus() == "CheckOut")
                    MessageBox.Show("client checked-out", "Checked-out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("The operation was not completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CheckIn()
        {
            currentBooking.CheckIn();
            Save();
        }
        public void CheckOut()
        {
            currentBooking.CheckOut();
            Save();
        }
        public Booking Select(int id)
        {
            foreach (var item in Booking.Items.Values)
                if (item.ID == id)
                    return item;
            return null;
        }

        public void GetInfo()
        {
            richTextBox.Clear();
            currentBooking = Select(Int32.Parse(textBox.Text));
            if (currentBooking != null)
            {
                richTextBox.AppendText("Client: " + currentBooking.Client.ToString() + "\n");
                richTextBox.AppendText("Hotel: " + currentBooking.Room.Hotel.ToString() + "\n");
                richTextBox.AppendText("Type of room: " + currentBooking.Room.RoomType.ToString() + "\n");
                richTextBox.AppendText("Room: " + currentBooking.Room.ToString() + "\n");
                richTextBox.AppendText("Arrival date: " + currentBooking.StartDate.Date.ToString("dd/MM/yyyy") + "\n");
                richTextBox.AppendText("Date of departure: " + currentBooking.EndDate.Date.ToString("dd/MM/yyyy") + "\n");
                richTextBox.AppendText("Cost: " + currentBooking.GetPrice().ToString() + "UAH " + "\n");
                richTextBox.AppendText("Status: " + currentBooking.GetStatus() + "\n");
            }
            else
                richTextBox.AppendText("No booking is available");
        }
    }
}
