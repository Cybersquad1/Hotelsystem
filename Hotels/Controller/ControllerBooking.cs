using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerBooking : Controller<Booking>
    {
        Dictionary<string, ComboBox> ComboBoxs = new Dictionary<string, ComboBox>();
        Dictionary<string, DateTimePicker> DateTimePickers = new Dictionary<string, DateTimePicker>();
        private bool makebooking = false;
        private Label labelTotal;
        public ControllerBooking(Dictionary<string, TextBox> textBoxs, Dictionary<string, ComboBox> comboBoxs, Dictionary<string, DateTimePicker> dateTimePickers,Label total):base(textBoxs)
        {
            foreach (var item in comboBoxs)
                ComboBoxs.Add(item.Key, item.Value);
            foreach (var item in dateTimePickers)
                DateTimePickers.Add(item.Key, item.Value);
            makebooking = true;
            labelTotal = total;
        }
        public ControllerBooking(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs, Dictionary<string,ComboBox> comboBoxs, Dictionary<string, DateTimePicker> dateTimePickers) :base(dgv,bn,textBoxs)
        {
            
            foreach (var item in comboBoxs)
            {
                ComboBoxs.Add(item.Key, item.Value);
            }
            foreach (var item in dateTimePickers)
            {
                DateTimePickers.Add(item.Key, item.Value);
            }
              ComboBoxs["Client"].DataBindings.Add("Text", bindingSource, "Client");
              ComboBoxs["Room"].DataBindings.Add("Text", bindingSource, "Room");
              DateTimePickers["StartDate"].DataBindings.Add("Text", bindingSource, "StartDate");
              DateTimePickers["EndDate"].DataBindings.Add("Text", bindingSource, "EndDate");
        }
        public override void Delete()
        {
            Booking temp = new Booking();
            temp.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
            temp.Delete();
        }
        
        //MakeBooking
        public void FillForm()
        {
            new Room().Get();
            new RoomType().Get();
            new Hotel().Get();
            new HotelRoomType().Get();
            ComboBoxs["Hotel"].DataSource = Hotel.Items.Values.ToList();
            ComboBoxs["RoomType"].DataSource = ((Hotel)(ComboBoxs["Hotel"].SelectedItem)).RoomTypes;
            ComboBoxs["Room"].DataSource = FindRoom((Hotel)(ComboBoxs["Hotel"].SelectedItem), (RoomType)((ComboBoxs["RoomType"].SelectedItem)));
            GetTotal();
        }
        public void GetTotal()
        {
            Booking temp = new Booking();
            temp.Room = (Room)ComboBoxs["Room"].SelectedItem;
            temp.StartDate = DateTimePickers["StartDate"].Value.Date;
            temp.EndDate = DateTimePickers["EndDate"].Value.Date;
            labelTotal.Text = temp.GetPrice().ToString();    
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
            Binding();
        }
        public void LoadClientDB()
        {
            Client currentUser = ControllerProfile.User;
            new Booking().SelectUserBooking(currentUser.ID);

            new Room().Get();
            new RoomType().Get();
            new Hotel().Get();
            new HotelRoomType().Get();

            new Client().Get();
            if(dataGridView != null)
                FillRows(Booking.Items.Values.ToArray());
            TextBoxs["Client"].Text = currentUser.ToString();
            List<Client> list = new List<Client>();
            list.Add(currentUser);
            ComboBoxs["Client"].DataSource = list;

            ComboBoxs["Hotel"].DataSource = Hotel.Items.Values.ToList();
            ComboBoxs["RoomType"].DataSource = ((Hotel)(ComboBoxs["Hotel"].SelectedItem)).RoomTypes;
            ComboBoxs["Room"].DataSource = FindRoom((Hotel)(ComboBoxs["Hotel"].SelectedItem), (RoomType)((ComboBoxs["RoomType"].SelectedItem)));
        }
        public void Binding()
        {
            if (dataGridView != null)
                FillRows(Booking.Items.Values.ToArray());
            ComboBoxs["Client"].DataSource = Client.Clients.Values.ToList();

            ComboBoxs["Hotel"].DataSource = Hotel.Items.Values.ToList();
            ComboBoxs["RoomType"].DataSource = ((Hotel)(ComboBoxs["Hotel"].SelectedItem)).RoomTypes;
            ComboBoxs["Room"].DataSource = FindRoom((Hotel)(ComboBoxs["Hotel"].SelectedItem), (RoomType)((ComboBoxs["RoomType"].SelectedItem)));
        }

        public List<Room> FindRoom(Hotel hotel, RoomType roomType)
        {
            List<Room> allrooms = Room.Items.Values.ToList();
            List<Room> rooms = new List<Room>();
            foreach (var room in allrooms)
            {
                if (room.Hotel.ID == hotel.ID && room.RoomType.ID == roomType.ID)
                    rooms.Add(room);
            }
            return rooms;

        }
        public void ChangeHotel()
        {
            ComboBoxs["RoomType"].DataSource = ((Hotel)(ComboBoxs["Hotel"].SelectedItem)).RoomTypes;
            ComboBoxs["Room"].DataSource = FindRoom((Hotel)(ComboBoxs["Hotel"].SelectedItem), (RoomType)((ComboBoxs["RoomType"].SelectedItem)));
            //FillRows(Room.Items.Values.ToArray());
        }
        public void ChangeRoomType()
        {
            //ComboBoxs["RoomType"].DataSource = ((Hotel)(ComboBoxs["Hotel"].SelectedItem)).RoomTypes;
            ComboBoxs["Room"].DataSource = FindRoom((Hotel)(ComboBoxs["Hotel"].SelectedItem), (RoomType)((ComboBoxs["RoomType"].SelectedItem)));
            //FillRows(Room.Items.Values.ToArray());
        }
        public override void Save()
        {
            Booking temp = new Booking();
            temp.Client = (Client)ComboBoxs["Client"].SelectedItem;
            
            temp.Room = (Room)ComboBoxs["Room"].SelectedItem;
            temp.StartDate = DateTimePickers["StartDate"].Value.Date;
            temp.EndDate = DateTimePickers["EndDate"].Value.Date;

            if (((DataRowView)bindingSource.Current).IsNew == true)
                temp.Insert();
            else
            {
                temp.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                temp.Update();
            }
        }
        public void SaveUserBooking()
        {
            Booking temp = new Booking();
            Person user = ControllerProfile.User;
            temp.Client = (Client)user;
            temp.Room = (Room)ComboBoxs["Room"].SelectedItem;
            temp.StartDate = DateTimePickers["StartDate"].Value.Date;
            temp.EndDate = DateTimePickers["EndDate"].Value.Date;

            if (makebooking || ((DataRowView)bindingSource.Current).IsNew == true)
                temp.Insert();
            else
            {
                temp.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                temp.Update();
            }
        }
        public override void FillColumns()
        {
            Type myType = typeof(Booking);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataColumn column;
            bool hotel = true;
            bool typeRoom = true;
            bool status = true;
            foreach (PropertyInfo prop in props)
            {
                column = new DataColumn();
                column.DataType = prop.PropertyType;
                column.ColumnName = prop.Name;
                column.ReadOnly = true;
                dataTable.Columns.Add(column);
                if (status)
                {
                    //Status
                    column = new DataColumn();
                    column.DataType = typeof(String);
                    column.ColumnName = "Status";
                    column.ReadOnly = true;
                    dataTable.Columns.Add(column);
                    status = false;
                }
                if (hotel)
                {
                    //Hotel
                    column = new DataColumn();
                    column.DataType = typeof(Hotel);
                    column.ColumnName = "Hotel";
                    column.ReadOnly = true;
                    dataTable.Columns.Add(column);
                    hotel = false;
                }
                if (typeRoom)
                {
                    //TypeRoom
                    column = new DataColumn();
                    column.DataType = typeof(RoomType);
                    column.ColumnName = "RoomType";
                    column.ReadOnly = true;
                    dataTable.Columns.Add(column);
                    typeRoom = false;
                }
            }
        }
        public override void AddRow(Booking currentrow)
        {
            Type myType = typeof(Booking);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo prop in props)
            {

                row[prop.Name] = prop.GetValue(currentrow, null);
            }
            row["Hotel"] = currentrow.Room.Hotel;
            row["RoomType"] = currentrow.Room.RoomType;
            row["Status"] = currentrow.GetStatus();
            dataTable.Rows.Add(row);
        }

        public bool IsValid()
        {
            if (DateTimePickers["StartDate"].Value.Date > DateTimePickers["EndDate"].Value.Date)
                return false;
            return true;
        }
    }
 }

