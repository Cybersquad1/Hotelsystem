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
                    MessageBox.Show("Клієнт поселений", "Поселення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (currentBooking.GetStatus() == "CheckOut")
                    MessageBox.Show("Клієнт виселений", "Виселення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Операція не виповнилась", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                richTextBox.AppendText("Клієнт: " + currentBooking.Client.ToString() + "\n");
                richTextBox.AppendText("Готель: " + currentBooking.Room.Hotel.ToString() + "\n");
                richTextBox.AppendText("Тип кімнати: " + currentBooking.Room.RoomType.ToString() + "\n");
                richTextBox.AppendText("Кімната: " + currentBooking.Room.ToString() + "\n");
                richTextBox.AppendText("Дата заїзду: " + currentBooking.StartDate.Date.ToString("dd/MM/yyyy") + "\n");
                richTextBox.AppendText("Дата виїзду: " + currentBooking.EndDate.Date.ToString("dd/MM/yyyy") + "\n");
                richTextBox.AppendText("Вартість: " + currentBooking.GetPrice().ToString() + " грн. " + "\n");
                richTextBox.AppendText("Статус: " + currentBooking.GetStatus() + "\n");
            }
            else
                richTextBox.AppendText("Бронювання відсутнє");
        }
    }
}
