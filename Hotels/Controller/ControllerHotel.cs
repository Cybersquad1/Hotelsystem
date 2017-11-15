using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotels.Controller
{
    public class ControllerHotel:Controller<Hotel>
    {
        private Chart chart;
        private ComboBox comboBox;
        private DateTimePicker dtp;
        public ControllerHotel(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs) : base(dgv, bn, textBoxs) { }
        public ControllerHotel(Chart ch, ComboBox cb, DateTimePicker mc)
        {
            chart = ch;
            comboBox = cb;
            dtp = mc;
        }

        public override void Save()
        {
            Hotel hotel = new Hotel();
            hotel.Name = TextBoxs["Name"].Text;
            hotel.City = TextBoxs["City"].Text;
            hotel.Street = TextBoxs["Street"].Text;
            hotel.Email = TextBoxs["Email"].Text;
            hotel.Telephone = TextBoxs["Telephone"].Text;

            if (((DataRowView)bindingSource.Current).IsNew == false)
                hotel.Insert();
            else
            {
                hotel.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                hotel.Update();
            }
        }
        public override void Delete()
        {
            Hotel hotel = new Hotel();
            hotel.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
            hotel.Delete();
        }
        public override void LoadDB()
        {
            new Hotel().Get();
            FillRows(Hotel.Items.Values.ToArray());
        }

        public void DrawChart()
        {
            new Booking().Get();
            new Hotel().Get();
            new Room().Get();
            new Person().Get();
            comboBox.DataSource = Hotel.Items.Values.ToList();
        }
        public void ChangeHotel()
        {
            Hotel hotel = (Hotel)comboBox.SelectedItem;
            Dictionary<string, int> dictonary = new Dictionary<string, int>();
            dictonary.Add("Free", 0);
            dictonary.Add("Booking", 0);
            dictonary.Add("CheckIn", 0);
            chart.Titles["Title"].Text = hotel.ToString() + " ( " + dtp.Value.Date.Date.ToString("dd MMM yyyy") + " )";
            foreach (Room room in hotel.Rooms.ToList())
            {
                foreach (Booking book in room.Bookings.ToList())
                {
                    if(book.StartDate.Date < dtp.Value.Date && book.EndDate.Date > dtp.Value.Date)
                        switch (book.GetStatus())
                        {
                            case "Booking":
                                dictonary["Booking"]++;
                                break;
                            case "CheckIn":
                                dictonary["CheckIn"]++;
                                break;
                            case "CheckOut":
                                dictonary["Free"]++;
                                break;
                            default:
                                dictonary["Free"]++;
                                break;
                        }
                    else
                        dictonary["Free"]++;

                    chart.Series["Status"].Points.Clear();
                    foreach (var item in dictonary)
                        chart.Series["Status"].Points.AddXY(item.Key, item.Value);
                }
            }
            
        }
    }
}
