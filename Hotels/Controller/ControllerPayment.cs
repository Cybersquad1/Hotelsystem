using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerPayment : Controller<Payment>
    {
        RichTextBox richTextBox;
        Payment payment;
        Dictionary<string, Label> Labels = new Dictionary<string, Label>();
        public ControllerPayment(RichTextBox RichTextBox,Dictionary<string, TextBox> textBoxs, Dictionary<string, Label> labels) :base(textBoxs)
        {
            richTextBox = RichTextBox;
            foreach (var item in labels)
                Labels.Add(item.Key,item.Value);
        }
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void LoadDB()
        {
            new Room().Get();
            new RoomType().Get();
            new Hotel().Get();
            new HotelRoomType().Get();
            new Booking().Get();
            new Person().Get();
            new Client().Get();
            new Payment().Get();
            payment = new Payment();
        }

        public override void Save()
        {
            if (payment.Pay(Convert.ToDecimal(TextBoxs["Amount"].Text)))
            {
                payment.Date = DateTime.Now;
                payment.Insert();
                MessageBox.Show("Payment was successful", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Payment failed", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Booking currentBooking = Select(Int32.Parse(TextBoxs["Search"].Text));
            if (currentBooking != null)
            {
                richTextBox.AppendText("Client: " + currentBooking.Client.ToString() + "\n");
                richTextBox.AppendText("Hotel: " + currentBooking.Room.Hotel.ToString() + "\n");
                richTextBox.AppendText("Type of room: " + currentBooking.Room.RoomType.ToString() + "\n");
                richTextBox.AppendText("Room: " + currentBooking.Room.ToString() + "\n");
                richTextBox.AppendText("Arrival date: " + currentBooking.StartDate.Date.ToString("dd/MM/yyyy") + "\n");
                richTextBox.AppendText("Date of departure: " + currentBooking.EndDate.Date.ToString("dd/MM/yyyy") + "\n");
                richTextBox.AppendText("Cost: " + currentBooking.GetPrice().ToString() + " UAH. " + "\n");
                richTextBox.AppendText("Status: " + currentBooking.GetStatus() + "\n");

                payment.Booking = currentBooking;

                currentBooking.Payments.ToList();
                Labels["Amount"].Text = payment.GetAmount().ToString();
                Labels["Remainder"].Text = payment.GetRemainder().ToString();
            }
            else
                richTextBox.AppendText("No booking is available");
        }
    }
}
